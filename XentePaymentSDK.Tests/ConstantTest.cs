using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XentePaymentSDK;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class ConstantTest
    {
        [TestMethod]
        [Description("The Auth URL from the Constant Class should be correct")]
        public void Test_ConstantAuthUrl_ShouldBeCorrect()
        {
            string BaseUrl = new Constant(false).BaseUrl;

            // The Auth URL should be correct
            Assert.AreEqual("http://34.90.206.233:83/api/v1", BaseUrl);
        }
    }
}
