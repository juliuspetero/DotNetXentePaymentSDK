namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;
    public class AuthCredential
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("password")]
        public string Pasword { get; set; }

        [JsonProperty("mode")]
        public Mode Mode { get; set; }

        public AuthCredential(string apiKey, string password, Mode mode)
        {
            this.ApiKey = apiKey;
            this.Pasword = password;
            this.Mode = mode;
        }
    }

    public enum Mode
    {
        Sandbox = 0,
        Production = 1
    }
}
