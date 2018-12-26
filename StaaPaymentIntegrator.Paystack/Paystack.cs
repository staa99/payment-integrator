using Staaworks.PaymentIntegrator.Paystack.Utilities;
using Staaworks.PaymentIntegrator.Providers;
using Staaworks.PaymentIntegrator.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack
{
    public partial class Paystack : IProvider
    {
        public string Name { get; protected set; }

        public string SecretKey { get; protected set; }

        public APICaller Caller { get; set; } = new PaystackCaller();

        /// <summary>
        /// This initializes paystack with the secret key and optionally the provider name as represented in your system which defaults to "PAYSTACK".
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="name"></param>
        public Paystack (string secretKey, string name = "PAYSTACK")
        {
            Name = name;
            SecretKey = secretKey;
        }
    }
}
