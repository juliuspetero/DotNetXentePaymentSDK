namespace XentePaymentSDK
{
    using System;
    using System.Collections.Generic;

    public class Validation
    {
        public static string ValidateTransactionRequest(TransactionRequest transactionRequest)
        {
            string validationErrors = null;
            if (transactionRequest.PaymentProvider == null)
            {
                validationErrors += "PaymentProvider cannot be empty; ";
            } 
            if (transactionRequest.Amount == null)
            {
                validationErrors += "Amount cannot be empty; ";
            }
            if (transactionRequest.Message == null)
            {
                validationErrors += "Mesage cannot be empty; ";
            }
            if (transactionRequest.CustomerId == null)
            {
                validationErrors += "Customer ID cannot be empty; ";
            }
            if (transactionRequest.CustomerPhone == null)
            {
                validationErrors += "Customer Phone cannot be empty; ";
            }
            if (transactionRequest.CustomerEmail == null)
            {
                validationErrors += "Customer Email cannot be empty; ";
            }
            if (transactionRequest.CustomerReference == null)
            {
                validationErrors += "Customer Reference cannot be empty; ";
            }
            if (transactionRequest.BatchId == null)
            {
                validationErrors += "Batch Id cannot be empty; ";
            }
            if (transactionRequest.RequestId == null)
            {
                validationErrors += "Request ID cannot be empty; ";
            }

            return validationErrors;
        }
    }
}
