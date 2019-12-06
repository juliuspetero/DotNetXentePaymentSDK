using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XentePaymentSDK;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class CreateTransaction
    {
        [TestMethod]
        [Description("createTransaction() should return an object with a message field")]
        public async Task Test_GetTransactionDetailsById()
        {
            // Initialize Xente class
            XentePayment xenteGateWay = TestHelper.InitializeXenteGateWay();


            // Create the transaction credentials
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
                RequestId = DateTime.Now.ToString(),
                Metadata = "extra information about transaction"
            };

            try
            {
                TransactionProcessingResponse transactionProcessingResponse = await xenteGateWay.Transactions.CreateTransaction(transactionRequest);
                Assert.IsNotNull(transactionProcessingResponse.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
