namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;
    public class BearerTokenResponse
    {
        [JsonPropertyAttribute("token")]
        public string BearerToken { get; set; }

        [JsonPropertyAttribute("message")]
        public string Message { get; set; }
    }
}
