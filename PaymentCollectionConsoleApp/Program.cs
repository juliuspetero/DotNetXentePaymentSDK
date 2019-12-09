using System;
using System.Threading.Tasks;
using XentePaymentSDK;

namespace PaymentCollectionConsoleApp
{
    class Program
    {
        private static XentePayment xentePaymentGateway => new XentePayment(apikey: "", password: "", mode: Mode.Sandbox);
       

        static void Main(string[] args)
        {
            // Create Transaction 
            CreateTransactionAsync().GetAwaiter().GetResult();

            ////Get transaction details by the transaction ID
            //GetTransactionDetailsAsync().GetAwaiter().GetResult();

            //////Get transaction details by the request ID
            //GetTransactionDetailsAsync2().GetAwaiter().GetResult();


            ////// Get Account Details
            //GetAccountDetailsAsync().GetAwaiter().GetResult();

            //////List all Payment Providers
            //GetAllPaymentProvidersAsync().GetAwaiter().GetResult();

            Console.ReadLine();

        }

        static void RunOther()
        {
            
        }

        // Create Transaction using Xente Payment SDK
        public static async Task CreateTransactionAsync()
        {

            // Create transaction request information
            TransactionRequest transactionRequest = new TransactionRequest
            {
                PaymentProvider = "MTNMOBILEMONEYUG",
                Amount = "800",
                Message = "Loan payment",
                CustomerId = "256778418592",
                CustomerPhone = "256778418592",
                CustomerEmail = "juliuspetero@outlook.com",
                CustomerReference = "256778418592",
                BatchId = "Batch001",
                RequestId = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Metadata = "extra information about transaction"
            };

            try
            {
                TransactionProcessingResponse transactionProcessingResponse = await xentePaymentGateway.Transactions.CreateTransaction(transactionRequest);

                Console.WriteLine("Message = {0}", transactionProcessingResponse.Message);
                Console.WriteLine("Code = {0}", transactionProcessingResponse.Code);
                Console.WriteLine("Correlation ID = {0}", transactionProcessingResponse.CorrelationId);
                Console.WriteLine("...............................................");
                Console.WriteLine("Data Information");
                Console.WriteLine("Message = {0}", transactionProcessingResponse.Data.Message);
                Console.WriteLine("Batch ID = {0}", transactionProcessingResponse.Data.BatchId);
                Console.WriteLine("Transaction ID = {0}", transactionProcessingResponse.Data.TransactionId);
                Console.WriteLine("Created On = {0}", transactionProcessingResponse.Data.CreatedOn);
                Console.WriteLine("Request ID = {0}", transactionProcessingResponse.Data.RequestId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task GetTransactionDetailsAsync()
        {
            const string transactionId = "292AA0F5BB5E4787B106F0C90182E9FE-256784378515";

            try
            {
                TransactionDetailsResponse transactionDetailsResponse = await xentePaymentGateway.Transactions.GetTransactionDetailsById(
                    transactionId
                    );
                Console.WriteLine("Message = {0}", transactionDetailsResponse.Message);
                Console.WriteLine("Code = {0}", transactionDetailsResponse.Code);
                Console.WriteLine("Correlation ID = {0}", transactionDetailsResponse.CorrelationId);
                Console.WriteLine("...............................................");
                Console.WriteLine("Data Information");
                Console.WriteLine("Transaction ID = {0}", transactionDetailsResponse.Data.TransactionId);
                Console.WriteLine("Request Reference ID = {0}", transactionDetailsResponse.Data.RequestReference);
                Console.WriteLine("Batch ID = {0}", transactionDetailsResponse.Data.BatchId);
                Console.WriteLine("Product = {0}", transactionDetailsResponse.Data.Product);
                Console.WriteLine("Provider = {0}", transactionDetailsResponse.Data.Provider);
                Console.WriteLine("Memo ID = {0}", transactionDetailsResponse.Data.Memo);
                Console.WriteLine("Type ID = {0}", transactionDetailsResponse.Data.Type);
                Console.WriteLine("Status ID = {0}", transactionDetailsResponse.Data.Status);
                Console.WriteLine("Status Message {0}", transactionDetailsResponse.Data.StatusMessage);
                Console.WriteLine("Amount = {0}", transactionDetailsResponse.Data.Amount);
                Console.WriteLine("Fee ID = {0}", transactionDetailsResponse.Data.Fee);
                Console.WriteLine("Customer ID = {0}", transactionDetailsResponse.Data.CustomerId);
                Console.WriteLine("Created On = {0}", transactionDetailsResponse.Data.CreatedOn);
                Console.WriteLine("Modified On = {0}", transactionDetailsResponse.Data.ModifiedOn);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public static async Task GetTransactionDetailsAsync2()
        {
            const string requestId = "08395c4627344c42b4582a7bf49116a1";

            try
            {
                TransactionDetailsResponse transactionDetailsResponse = await xentePaymentGateway.Transactions.GetTransactionDetailsByRequestId(
                    requestId
                    );
                Console.WriteLine("Message = {0}", transactionDetailsResponse.Message);
                Console.WriteLine("Code = {0}", transactionDetailsResponse.Code);
                Console.WriteLine("Correlation ID = {0}", transactionDetailsResponse.CorrelationId);
                Console.WriteLine("...............................................");
                Console.WriteLine("Data Information");
                Console.WriteLine("Transaction ID = {0}", transactionDetailsResponse.Data.TransactionId);
                Console.WriteLine("Request Reference ID = {0}", transactionDetailsResponse.Data.RequestReference);
                Console.WriteLine("Batch ID = {0}", transactionDetailsResponse.Data.BatchId);
                Console.WriteLine("Product = {0}", transactionDetailsResponse.Data.Product);
                Console.WriteLine("Provider = {0}", transactionDetailsResponse.Data.Provider);
                Console.WriteLine("Memo ID = {0}", transactionDetailsResponse.Data.Memo);
                Console.WriteLine("Type ID = {0}", transactionDetailsResponse.Data.Type);
                Console.WriteLine("Status ID = {0}", transactionDetailsResponse.Data.Status);
                Console.WriteLine("Status Message {0}", transactionDetailsResponse.Data.StatusMessage);
                Console.WriteLine("Amount = {0}", transactionDetailsResponse.Data.Amount);
                Console.WriteLine("Fee ID = {0}", transactionDetailsResponse.Data.Fee);
                Console.WriteLine("Customer ID = {0}", transactionDetailsResponse.Data.CustomerId);
                Console.WriteLine("Created On = {0}", transactionDetailsResponse.Data.CreatedOn);
                Console.WriteLine("Modified On = {0}", transactionDetailsResponse.Data.ModifiedOn);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public static async Task GetAccountDetailsAsync()
        {
            //Get account details
            const string accountId = "256784378515";
            try
            {
                AccountResponse accountResponse = await xentePaymentGateway.Accounts.GetAccountDetailsById(accountId);
                Console.WriteLine("Message = {0}", accountResponse.Message);
                Console.WriteLine("Code = {0}", accountResponse.Code);
                Console.WriteLine("Correlation ID = {0}", accountResponse.CorrelationId);
                Console.WriteLine("...............................................");
                Console.WriteLine("Data Information");
                Console.WriteLine("Created On = {0}", accountResponse.Data.CreateOn);
                Console.WriteLine("Modified On = {0}", accountResponse.Data.ModifiedOn);
                Console.WriteLine("Account ID = {0}", accountResponse.Data.AccountId);
                Console.WriteLine("Subscription ID = {0}", accountResponse.Data.SubscriptionId);
                Console.WriteLine("Account Type = {0}", accountResponse.Data.AccountType);
                Console.WriteLine("Currency Code = {0}", accountResponse.Data.CurrencyCode);
                Console.WriteLine("Country Code = {0}", accountResponse.Data.CountryCode);
                Console.WriteLine("Account Status = {0}", accountResponse.Data.AccountStatus);
                Console.WriteLine("Name = {0}", accountResponse.Data.Name);
                Console.WriteLine("Short Description = {0}", accountResponse.Data.ShortDescription);
                Console.WriteLine("Long Description = {0}", accountResponse.Data.LongDescription);
                Console.WriteLine("Alert Level = {0}", accountResponse.Data.AlertLevel);
                Console.WriteLine("Alert channel = {0}", accountResponse.Data.AlertChannel);
                Console.WriteLine("Alert Email Address = {0}", accountResponse.Data.AlertEmailAddress);
                Console.WriteLine("Alert Phone Number = {0}", accountResponse.Data.AlertPhoneNumber);
                Console.WriteLine("Callback URI = {0}", accountResponse.Data.CallBackUri);
                Console.WriteLine("Balance = {0}", accountResponse.Data.Balance);
                Console.WriteLine("Account Package = {0}", accountResponse.Data.AccountPackage);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public static async Task GetAllPaymentProvidersAsync()
        {
            try
            {
                string dottedLine = "...............................................";
                PaymentProvidersResponse paymentProvidersResponse = await xentePaymentGateway.PaymentProviders.GetPaymentProviders();
                Console.WriteLine("Message = {0}", paymentProvidersResponse.Message);
                Console.WriteLine("Code = {0}", paymentProvidersResponse.Code);
                Console.WriteLine("Correlation ID = {0}{1}\n", paymentProvidersResponse.CorrelationId, dottedLine);

                Console.WriteLine("Data Information");
                Console.WriteLine("Current Page = {0}", paymentProvidersResponse.Data.CurrentPage);
                Console.WriteLine("Page Size = {0}", paymentProvidersResponse.Data.PageSize);
                Console.WriteLine("Total Page = {0}", paymentProvidersResponse.Data.TotalPages);
                Console.WriteLine("Previous Page = {0}", paymentProvidersResponse.Data.PreviousPage);
                Console.WriteLine("Next Page = {0}{1}\n", paymentProvidersResponse.Data.NextPage, dottedLine);

                Console.WriteLine($"Payment Providers Colection\n{dottedLine}");

                foreach (PaymentProviderResponse paymentProviderResponse in paymentProvidersResponse.Data.Collection)
                {
                    Console.WriteLine("Payment Provider with ID = {0}", paymentProviderResponse.PaymentId);
                    Console.WriteLine("Payment ID = {0}", paymentProviderResponse.PaymentId);
                    Console.WriteLine("Image URI = {0}", paymentProviderResponse.ImageUri);
                    Console.WriteLine("Name = {0}", paymentProviderResponse.Name);
                    Console.WriteLine("Category = {0}", paymentProviderResponse.Category);
                    Console.WriteLine("Short Description = {0}", paymentProviderResponse.ShortDescription);
                    Console.WriteLine("Long Description = {0}", paymentProviderResponse.LongDescription);
                    Console.WriteLine("Country Code = {0}", paymentProviderResponse.CountryCode);
                    Console.WriteLine("Currency Code = {0}", paymentProviderResponse.CurrencyCode);
                    Console.WriteLine("Is Deleted = {0}", paymentProviderResponse.IsDeleted);
                    Console.WriteLine("Is Active = {0}", paymentProviderResponse.IsActive);
                    Console.WriteLine("Is External = {0}", paymentProviderResponse.IsExternal);
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }

    }
}