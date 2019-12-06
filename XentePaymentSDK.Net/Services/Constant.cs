namespace XentePaymentSDK
{
    using System;
    public class Constant
    {
        private string ProductionUrl = "https://payments.xente.co";
        private string SandboxUrl = "http://34.90.206.233:83";
        /// <summary>
        /// Get or Set the BaseUrl
        /// </summary>
        public string BaseUrl { get; set; }
        public Constant(bool isProduction)
        {
            if (isProduction == true)
            {
                this.BaseUrl = $"{ProductionUrl}/api/v1";
            }
            else
            {
                this.BaseUrl = $"{SandboxUrl}/api/v1";
            }
        }
        
    }
}
