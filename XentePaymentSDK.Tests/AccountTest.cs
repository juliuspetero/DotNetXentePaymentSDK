using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XentePaymentSDK;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        [Description("GetAccountDetailsById() should return AccountResults with a message field")]
        public async Task Test_GetAccountDetailsById_Method()
        {
            // Initialize Xente class
            XentePayment xenteGateWay = TestHelper.InitializeXenteGateWay();

            // A valid Account ID
            const string accountId = "256784378515";

            AccountResponse accountResponse = await xenteGateWay.Accounts.GetAccountDetailsById(accountId);

            // The message should exist and not be null
            Assert.IsNotNull(accountResponse.Message);

        }
    }
}
