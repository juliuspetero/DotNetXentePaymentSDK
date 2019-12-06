/// <summary>
/// Defines the Xente class as the entry point class an integrator can instantiate
/// </summary>
namespace XentePaymentSDK
{
    using System;

    /// <summary>
    /// The class allows the integrator to interface with the components of the SDK upon instantiation
    /// </summary>
    public class XentePayment
    {
        /// <summary>
        /// The Authentication credential as a property
        /// </summary>
        private AuthCredential AuthCredentials { get; set; }

        /// <summary>
        /// The Account as a property 
        /// </summary>
        public Account Accounts { get; set; }


        /// <summary>
        /// The Transaction as a property 
        /// </summary>
        public Transaction Transactions { get; set; }

        /// <summary>
        /// The Payment Provider as a property
        /// </summary>
        public PaymentProvider PaymentProviders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="XentePayment"/> class
        /// </summary>
        /// <param name="apikey"></param>
        /// The apikey attainable from the developer portal
        /// <param name="password"></param>
        /// Your developer account password
        /// <param name="mode"></param>
        public XentePayment(string apikey, string password, Mode mode)
        {
            // Initialize the properties in the constructor
            this.AuthCredentials = new AuthCredential(apikey, password, mode );
            this.Accounts = new Account(this.AuthCredentials);
            this.Transactions = new Transaction(this.AuthCredentials);
            this.PaymentProviders = new PaymentProvider(this.AuthCredentials);
        }
    }
}
