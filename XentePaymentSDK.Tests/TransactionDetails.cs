using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XentePaymentSDK;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class TransactionDetails
    {
        [TestMethod]
        [Description("GetTransactionDetailsById() should return an object with a message field")]
        public async Task Test_GetTransactionDetailsById()
        {
            // Initialize Xente class
            XentePayment xenteGateWay = TestHelper.InitializeXenteGateWay();

            // A valid Account ID
            const string transactionId = "46149FE350254038BC40C7091F9F5AF1-256784378515";

            TransactionDetailsResponse transactionDetailsResults = await xenteGateWay.Transactions.GetTransactionDetailsById(transactionId);

            // The message should exist and not be null
            Assert.IsNotNull(transactionDetailsResults.Message);
        }
    }
}
