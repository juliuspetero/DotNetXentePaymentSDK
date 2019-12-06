using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XentePaymentSDK;

namespace XentePaymentSDK.Tests
{
    [TestClass]
    public class BearerTokenTest
    {
        [TestMethod]
        [Description("The Bearer Token should be generated from the Xente API")]
        public void Test_ExecuteBearerToken_WithCorrectCredential()
        {
            try
            {
                string bearerToken = TestHelper.InitializeHttpRequestClientWithCorrectCredential().ExecuteBearerTokenRequest().GetAwaiter().GetResult();

                // Check that the Bearer Token is actually generated and kept in the variable
                Assert.IsNotNull(bearerToken);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        [TestMethod]
        [Description("The Bearer Token should not be generated from the Xente API")]
        public void Test_ExecuteBearerToken_WithWrongCredential()
        {
            try
            {
                HttpRequestClient httpRequestClient = TestHelper.InitializeHttpRequestClientWithCorrectCredential();
                string bearerToken = httpRequestClient.ExecuteBearerTokenRequest().GetAwaiter().GetResult();
            }
            catch (XenteIncorrectRequestException ex)
            {
                Assert.AreEqual("Incorrect Authentication Credentials", ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        [Description("ExecuteBearerToken() should update this.BearerToken global variable")]
        public void Test_ExecuteBearerToken_ToUpdate_TheGlobalBearerToken()
        {
            try
            {
                HttpRequestClient httpRequestClient = TestHelper.InitializeHttpRequestClientWithCorrectCredential();
                string bearerToken = httpRequestClient.ExecuteBearerTokenRequest().GetAwaiter().GetResult();

                // Check that the Bearer Token generated is equal to the one in the global variable
                Assert.AreEqual(bearerToken, httpRequestClient.BearerToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }


        [TestMethod]
        [Description("The Bearer Token in the global variable should be used first for making request")]
        public void Test_TheGeneratedToken_shouldBe_UsedFor_SubsequentRequest()
        {
            try
            {
                HttpRequestClient httpRequestClient = TestHelper.InitializeHttpRequestClientWithCorrectCredential();

                // Generate a token a keep it in variable generatedBearerToken
                string generatedBearerToken = httpRequestClient.ExecuteBearerTokenRequest().GetAwaiter().GetResult();

                // Make request to the API (e.g. create transaction, get transaction etc.)
                AccountResponse accountResults = httpRequestClient.ExecuteAccountRequest("256784378515").GetAwaiter().GetResult();

                string bearerTokenUsedForRetrievingAccountDetails = httpRequestClient.BearerToken;

                // Check that the two bearer tokens are the same
                Assert.AreEqual(generatedBearerToken, bearerTokenUsedForRetrievingAccountDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
