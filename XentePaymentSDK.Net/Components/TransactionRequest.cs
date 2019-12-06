namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;

    public class TransactionRequest
    {
        /// <summary>
        /// The company to initiate payment e.g. MTN, Airtel etc.
        /// </summary>
        [JsonProperty("paymentProvider")]
        public string PaymentProvider { get; set; }

        /// <summary>
        /// The amount of money to be paid
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The Message decribing what the transaction is about
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The unique string identifier of a customer in the payment collector site
        /// </summary>
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The customer Phone number
        /// </summary>
        [JsonProperty("customerPhone")]
        public string CustomerPhone { get; set; }

        /// <summary>
        /// The email of the person making the payment
        /// </summary>
        [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The the phone number where the transaction will be initiated
        /// </summary>
        [JsonProperty("customerReference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// The string identifier for the batch or the collection of requests
        /// </summary>
        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The unique string identifier of each request to the API
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Additional information to be added in dictionary type
        /// </summary>
        [JsonProperty("metadata")]
        public string Metadata { get; set; }

    }
}
