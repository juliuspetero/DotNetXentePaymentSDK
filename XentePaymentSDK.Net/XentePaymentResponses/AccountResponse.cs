namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;

    public class AccountResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("data")]
        public AccountData Data { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }

    }

    public class AccountData
    {
        [JsonProperty("createdOn")]
        public string CreateOn { get; set; }

        [JsonProperty("modifiedOn")]
        public string ModifiedOn { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }


        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [JsonProperty("alertLevel")]
        public string AlertLevel { get; set; }

        [JsonProperty("alertChannel")]
        public string AlertChannel { get; set; }

        [JsonProperty("alertEmailAddress")]
        public string AlertEmailAddress { get; set; }

        [JsonProperty("alertPhoneNumber")]
        public string AlertPhoneNumber { get; set; }

        [JsonProperty("callBackUri")]
        public string CallBackUri { get; set; }

        [JsonProperty("balance")]
        public Double Balance { get; set; }

        [JsonProperty("accountPackage")]
        public string AccountPackage { get; set; }
    }
}
