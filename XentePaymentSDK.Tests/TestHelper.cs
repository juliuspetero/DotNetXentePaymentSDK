using System;
using System.Collections.Generic;
using System.Text;

namespace XentePaymentSDK.Tests
{
    class TestHelper
    {
        public static XentePayment InitializeXenteGateWay()
        {
            //Authenication Credentias
            const string apikey = "6A19EA2A706041A599375CC95FF08809";

            const string password = "Demo123456";

            const Mode mode = Mode.Sandbox;

            // Initialize the Xente class

            XentePayment xenteGateWay = new XentePayment(apikey, password, mode);

            return xenteGateWay;
        }

        public static HttpRequestClient InitializeHttpRequestClientWithCorrectCredential()
        {
            //Authenication Credentias
            const string apikey = "6A19EA2A706041A599375CC95FF08809";

            const string password = "Demo123456";

            const Mode mode = Mode.Sandbox;


            AuthCredential authCredential = new AuthCredential(apikey, password, mode);

            HttpRequestClient httpRequestClient = HttpRequestClient.GetInstance(authCredential);
            return httpRequestClient;
        }
        
        public static HttpRequestClient InitializeHttpRequestClientWithWrongCredential()
        {
            //Authenication Credentias
            const string apikey = "WrongApikey";

            const string password = "WrongPassword";

            const Mode mode = Mode.Sandbox;


            AuthCredential authCredential = new AuthCredential(apikey, password, mode);

            HttpRequestClient httpRequestClient = HttpRequestClient.GetInstance(authCredential);
            return httpRequestClient;
        }
    }
}
