namespace XentePaymentSDK
{
    using System;
    using System.Net;

    /// <summary>
    ///  Represents a connection error that occurred in the Xente SDK when attempting to make an HTTP request to the Xente REST API.
    /// </summary>
    class XenteConnectionException : XenteException
    {
        /// <summary>
        /// Initialize a new <seealso cref="XenteConnectionException"/> with no exception details set
        /// Represents an error that occurs when when making a connection with Xente API
        /// </summary>
        public XenteConnectionException() : base(string.Empty)
        {

        }

        /// <summary>
        /// Represents an error that occurs when making a connection with Xente API
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        public XenteConnectionException(string message) : base(message)
        {

        }

        /// <summary>
        /// Represents an error that occurs when making a connection with Xente API
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>

        public XenteConnectionException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
