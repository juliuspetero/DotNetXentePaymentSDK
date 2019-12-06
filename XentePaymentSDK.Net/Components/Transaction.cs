namespace XentePaymentSDK
{
    using System;
    using System.Threading.Tasks;

    public class Transaction
    {
        private AuthCredential AuthCredential { get; set; }
        private HttpRequestClient HttpRequestClient { get; set; }
        public Transaction(AuthCredential authCredential) 
        {
            this.AuthCredential = authCredential;
            this.HttpRequestClient = HttpRequestClient.GetInstance(this.AuthCredential);
        }

        public async Task<TransactionProcessingResponse> CreateTransaction(TransactionRequest transactionRequest)
        {
            // Validate that all the transaction request values are present
            string validationErrors = Validation.ValidateTransactionRequest(transactionRequest);

            if (validationErrors != null)
            {
                throw new XenteMissingRequestException(validationErrors);
            }

            TransactionProcessingResponse transactionProcessingResponse = await
                this.HttpRequestClient.ExecuteTransactionRequest(transactionRequest);

            return transactionProcessingResponse;
        }

        // Get transaction by the transaction Id provided
        public async Task<TransactionDetailsResponse> GetTransactionDetailsById(string transactionId )
        {
            TransactionDetailsResponse transactionDetailsResponse = await
            this.HttpRequestClient.ExecuteTransactionDetailsRequest(transactionId);

            return transactionDetailsResponse; 
        }

        // Get transaction by the by the request Id set by the user
        public async Task<TransactionDetailsResponse> GetTransactionDetailsByRequestId(string requestId)
        {
            TransactionDetailsResponse transactionDetailsResponse = await
            this.HttpRequestClient.ExecuteTransactionDetailsRequest2(requestId);

            return transactionDetailsResponse;
        }
    }
}
