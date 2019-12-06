namespace XentePaymentSDK
{
    using System;

    /// <summary>
    /// Represents an error that occur in the Xente SDK
    /// </summary>
    public class XenteException : Exception
    {
        /// <summary>
        /// Initialize a new <seealso cref="XenteException"/> with no exception details set
        /// </summary>
        public XenteException() : base(string.Empty)
        {

        }

        /// <summary>
        /// Represents errors that occur during application execution
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        public XenteException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>

        public XenteException(string message, Exception innerException) : base (message, innerException)
        {

        }

      
    }
}
