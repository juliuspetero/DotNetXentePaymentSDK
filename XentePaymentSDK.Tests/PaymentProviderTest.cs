using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class PaymentProviderTest
    {
        [TestMethod]
        [Description("GetPaymentProviders() should return a list of payment providers")]
        public async Task Test_GetPaymentProviders()
        {
            // Initialize Xente class
            XentePayment xenteGateWay = TestHelper.InitializeXenteGateWay();

            PaymentProvidersResponse paymentProvidersResponse = await xenteGateWay.PaymentProviders.GetPaymentProviders();

            // The length of the payment providers should be greater than zero
            Assert.IsTrue(paymentProvidersResponse.Data.Collection.Count > 0);  
        }
    }
}
