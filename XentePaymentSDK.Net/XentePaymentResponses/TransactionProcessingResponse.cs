﻿namespace XentePaymentSDK
{
    using Newtonsoft.Json;
    using System;
    public class TransactionProcessingResponse
    {
        /// <summary>
        /// Set or Get status message
        /// </summary>

        [JsonPropertyAttribute("message")]
        public string Message { get; set; }
        /// <summary>
        /// Get or Set the status code
        /// </summary>

        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// Get or set data about the transaction Results
        /// </summary>

        [JsonProperty("data")]
        public ProcessingData Data { get; set; }

        /// <summary>
        /// correlation ID
        /// </summary>
        [JsonProperty("correlationId")]
        public string CorrelationId { get; set; }
    }

    public class ProcessingData
    {
        /// <summary>
        /// The Request ID for each transaction should be unique
        /// </summary>

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Batch ID for a particular collection or batch
        /// </summary>
        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// Transaction ID generated by Xente for each transaction
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Message telling the user the status of the transaction
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The date at which the transaction is created
        /// </summary>

        [JsonProperty("createdOn")]
        public string CreatedOn { get; set; }
    }
}