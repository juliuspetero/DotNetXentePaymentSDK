namespace XentePaymentSDK
{
    using System;

    /// <summary>
    /// Represents an error that occurred in the Xente Payment SDK when request parameters are required but missing.
    /// </summary>
    class XenteMissingRequestException : XenteException
    {
        /// <summary>
        /// Represents errors where certain credential information is required but missing.
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public XenteMissingRequestException(string message) :base(message)
        {

        }
    }
}
