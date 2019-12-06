namespace XentePaymentSDK
{
    using System;
    using System.Threading.Tasks;

    public class Account
    {
        private AuthCredential AuthCredential { get; set; }
        private HttpRequestClient HttpRequestClient { get; set; }
       

        public Account(AuthCredential authCredential)
        {
            this.AuthCredential = authCredential;
            this.HttpRequestClient = HttpRequestClient.GetInstance(this.AuthCredential);
        }

        public async Task<AccountResponse> GetAccountDetailsById(string accountId)
        {
            AccountResponse accounResponse = await
                this.HttpRequestClient.ExecuteAccountRequest(accountId);

            return accounResponse;
        }
    }
}
