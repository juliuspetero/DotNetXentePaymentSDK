namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class PaymentProvidersResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("data")]
        public PaymentProvidersData Data { get; set; }

        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }
    }

    public class PaymentProvidersData
    {
        
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("collection")]
        public List<PaymentProviderResponse> Collection { get; set; }

        [JsonProperty("previousPage")]
        public bool PreviousPage { get; set; }

        [JsonProperty("nextPage")]
        public bool NextPage { get; set; }
    }

    public class PaymentProviderResponse
    {
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("imageUri")]
        public string ImageUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("longDescription")]
        public string LongDescription { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isExternal")]
        public bool IsExternal { get; set; }
    }
}
