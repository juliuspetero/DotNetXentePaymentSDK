namespace XentePaymentSDK
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PaymentProvider
    {
        private AuthCredential AuthCredential { get; set; }
        private HttpRequestClient HttpRequestClient { get; set; }

        public PaymentProvider(AuthCredential authCredential)
        {
            this.AuthCredential = authCredential;
            this.HttpRequestClient = HttpRequestClient.GetInstance(this.AuthCredential);
        }

        public async Task<PaymentProvidersResponse> GetPaymentProviders()
        {
            PaymentProvidersResponse paymentProvidersResponse = await 
                this.HttpRequestClient.ExecutePaymentProvidersRequest();

            return paymentProvidersResponse;
        }
    }
}
