namespace XentePaymentSDK
{
    using System;

    public class XenteIncorrectRequestException : XenteException
    {
        /// <summary>
        /// Initialize a new <seealso cref="XenteIncorrectRequestException"/> with no exception details set
        /// Represents errors that occur when apikey, password or the mode is inco
        /// </summary>
        public XenteIncorrectRequestException() : base(string.Empty)
        {

        }

        /// <summary>
        /// Represents errors that occur when apikey, password or the mode is incorrect
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        public XenteIncorrectRequestException(string message) : base(message)
        {

        }

        /// <summary>
        /// Represents errors that occur when apikey, password or the mode is incorrect
        /// </summary>
        /// <param name="message">The message that describe the error</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>

        public XenteIncorrectRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
