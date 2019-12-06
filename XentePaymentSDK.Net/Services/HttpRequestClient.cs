namespace XentePaymentSDK
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HttpRequestClient
    {
        // Implementation of singleton
        // Singleton instance is stored in static field to be accessed before the class instantiation
        private static HttpRequestClient _instance;

        /// <summary>
        /// Configures the authentication credentials instead of the constructor
        /// </summary>
        /// <param name="authCredential"></param>
        public static HttpRequestClient GetInstance(AuthCredential authCredential)
        {
            if (_instance == null)
            {
                _instance = new HttpRequestClient(authCredential);
            }
            return _instance;
        }

        /// <summary>
        /// Get or set the HttpClient class for making all the HttpRequests
        /// </summary>
        private HttpClient HttpClient { get; set; }

        /// <summary>
        /// AuthCredential property
        /// </summary>
        private AuthCredential AuthCredential { get; set; }

        /// <summary>
        /// The constant property contains all the URLs needed
        /// </summary>
        private Constant Constant { get; set; }

        /// <summary>
        /// This holds the bearer token during runtime
        /// </summary>
        public string BearerToken { get; set; }

        /// <summary>
        /// nitialize a new instance of the <see cref="HttpRequestClient"/> class
        /// </summary>
        /// <param name="authCredential"></param>
        /// The authCredentail which contains apikey, password and mode as it fields
        private HttpRequestClient(AuthCredential authCredential)
        {
            this.AuthCredential = authCredential;
            this.HttpClient = new HttpClient();

            if (this.AuthCredential.Mode ==  Mode.Production)
            {
                this.Constant = new Constant(true);
            }
            else
            {
                this.Constant = new Constant(false);
            }

            // Set the intial http Request parameters
            this.HttpClient.BaseAddress = new Uri(this.Constant.BaseUrl);
            SetRequestHeaders();
        }


        // Set all the headers parameters for making HTTP request
        private void SetRequestHeaders()
        {
            // Clears the headers values to set in order to avoid 403 for expired X-Date
            this.HttpClient.DefaultRequestHeaders.Clear();

            // Content tyoe is application/json
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Add the ApiKey to the headers for all the request
            this.HttpClient.DefaultRequestHeaders.Add("X-ApiAuth-ApiKey", this.AuthCredential.ApiKey);

            // Set the bearer token in the headers for all the request
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.BearerToken);

            this.HttpClient.DefaultRequestHeaders.Add("X-Date", DateTime.UtcNow.ToString("o"));
            this.HttpClient.DefaultRequestHeaders.Add("X-Correlation-ID", DateTime.UtcNow.ToString("o"));
        }


        // Generate the bearer and update the global variable
        public async Task<string>  ExecuteBearerTokenRequest()
        {
            try
            {
                // Set the necessary headers paramters
                SetRequestHeaders();

                // Make Http request to the Xente Payment API
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"{Constant.BaseUrl}/Auth/login", this.AuthCredential);

                // Throw an exception in case of any errors
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    // Cast the Json object to the our custome type 
                    BearerTokenResponse bearerTokenResponse = await response.Content.ReadAsAsync<BearerTokenResponse>();

                    // The global BearerToken property is updated when a new token is requested from the API
                    this.BearerToken = bearerTokenResponse.BearerToken;
                }
                return this.BearerToken;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    throw new XenteIncorrectRequestException("Incorrect Authentication Credential Provided");
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
                
            }
            
        }

        /// <summary>
        /// This is use to make transaction to the Xente API
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// 
        public async Task<TransactionProcessingResponse> ExecuteTransactionRequest(TransactionRequest transactionRequest, bool executeWithANewToken = false)
        {
            //Check if the token is present in the global variable or when executeWithANewToken is true
            if (this.BearerToken == null || executeWithANewToken == true)
            {
                this.BearerToken = await ExecuteBearerTokenRequest();
            }

            try
            {
                SetRequestHeaders();

                // Create a transaction by making a post request to Xente payment API
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"{Constant.BaseUrl}/transactions", transactionRequest);

                // Throw an exception when the transaction is not successful
                response.EnsureSuccessStatusCode();

                // Cast the Json response to a custom type
                TransactionProcessingResponse transactionProcessingResponse = await response.Content.ReadAsAsync<TransactionProcessingResponse>();

                return transactionProcessingResponse;
            }
            catch (Exception ex)
            {
                if (this.BearerToken != null && ex.Message.Contains("401"))
                {
                    // Repeat the execution of this function but with a new bearer token
                    TransactionProcessingResponse transactionProcessingResultsWithNewToken = await ExecuteTransactionRequest(transactionRequest, true);
                    return transactionProcessingResultsWithNewToken;
                }
                else if (ex.Message.Contains("400"))
                {
                    throw new XenteIncorrectRequestException("Incorrect Transaction Request body Provided");
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
            }
        }

        // Get transaction Details by the their respective Transaction IDs
        public async Task<TransactionDetailsResponse> ExecuteTransactionDetailsRequest(string transactionId, bool executeWithANewToken = false)
        {
            // Check if the token is present in the global variable or when executeWithANewToken is true
            if (this.BearerToken == null || executeWithANewToken == true)
            {
                this.BearerToken = await ExecuteBearerTokenRequest();
            } 

            try
            {
                // Set the Http Request parameters
                SetRequestHeaders();

                // Make an Http requets to get the transaction details
                HttpResponseMessage response = await HttpClient.GetAsync($"{this.Constant.BaseUrl}/transactions/{transactionId}");

                // Throw an exception in case of any errors
                response.EnsureSuccessStatusCode();

                // Cast the Json response to our custom type
                TransactionDetailsResponse transactionDetailsResponse = await response.Content.ReadAsAsync<TransactionDetailsResponse>();

                return transactionDetailsResponse;
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    // Repeat the execution but with a new bearer token
                    TransactionDetailsResponse transactionDetailsResultsWithNewToken = await ExecuteTransactionDetailsRequest(transactionId, true);
                    return transactionDetailsResultsWithNewToken;
                }
                else if (ex.Message.Contains("400"))
                {
                    // Incorrect Transaction ID is provided (400)
                    throw new XenteIncorrectRequestException("Incorrect Transaction ID provided");
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
            }
        }


        // Get transaction details by the their respective Request Ids sent by the user
        public async Task<TransactionDetailsResponse> ExecuteTransactionDetailsRequest2(string requestId, bool executeWithANewToken = false)
        {
            // Check if the token is present in the global variable or when executeWithANewToken is true
            if (this.BearerToken == null || executeWithANewToken == true)
            {
                this.BearerToken = await ExecuteBearerTokenRequest();
            }

            try
            {
                // Set the Http Request parameters
                SetRequestHeaders();

                HttpResponseMessage response = await HttpClient.GetAsync($"{this.Constant.BaseUrl}/transactions/Requests/{requestId}");

                response.EnsureSuccessStatusCode();

                TransactionDetailsResponse transactionDetailsResponse = await response.Content.ReadAsAsync<TransactionDetailsResponse>();

                return transactionDetailsResponse;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    // Repeat the execution but with a new bearer token
                    TransactionDetailsResponse transactionDetailsResultsWithNewToken = await ExecuteTransactionDetailsRequest(requestId, true);
                    return transactionDetailsResultsWithNewToken;
                }
                else if (ex.Message.Contains("400"))
                {
                    // Incorrect Request ID is provided (400)
                    throw new XenteIncorrectRequestException("Incorrect Request Id Provided");
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
            }
        }

        // Get the account details the user
        public async Task<AccountResponse> ExecuteAccountRequest(string accountId, bool executeWithANewToken = false)
        {
            // Check if the token is present in the global variable or when executeWithANewToken is true
            if (this.BearerToken == null || executeWithANewToken == true)
            {
                this.BearerToken = await ExecuteBearerTokenRequest();
            }

            try
            {
                SetRequestHeaders();

                // Make an Http request to retrieve user account information
                HttpResponseMessage response = await HttpClient.GetAsync($"{this.Constant.BaseUrl}/Accounts/{accountId}");
                response.EnsureSuccessStatusCode();
                
                // Cast the Json response to our custom data type
                AccountResponse accounResponse = await response.Content.ReadAsAsync<AccountResponse>();

                return accounResponse;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    // Repeat the execution but with a new bearer token
                    AccountResponse accountResultsWithNewToken = await ExecuteAccountRequest(accountId, true);
                    return accountResultsWithNewToken;
                }
                else if (ex.Message.Contains("400"))
                {
                    // Incorrect account ID (Bad Request)
                    throw new XenteIncorrectRequestException("Incorrect Account ID Provided");
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
            }
        }

        // List all payment provided Xente Payment API is integrated with
        public async Task<PaymentProvidersResponse> ExecutePaymentProvidersRequest(bool executeWithANewToken = false)
        {
            // Check if the token is present in the global variable or when executeWithANewToken is true
            if (this.BearerToken == null || executeWithANewToken == true)
            {
                this.BearerToken = await ExecuteBearerTokenRequest();
            }

            try
            {
                SetRequestHeaders();

                HttpResponseMessage response = await HttpClient.GetAsync($"{this.Constant.BaseUrl}/PaymentProviders/MOBILEMONEYUG/providerItems?PageSize=10&PageNumber=1");

                response.EnsureSuccessStatusCode();

                // Cast the response to our custome data type 
                PaymentProvidersResponse paymentProvidersResponse = await response.Content.ReadAsAsync<PaymentProvidersResponse>();

                return paymentProvidersResponse;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    // Execute again but with a new bearer token
                    PaymentProvidersResponse paymentProvidersResultsWithNewToken = await ExecutePaymentProvidersRequest(true);
                    return paymentProvidersResultsWithNewToken;
                }
                else
                {
                    throw new XenteConnectionException(ex.Message);
                }
            }

        }
    }
}
