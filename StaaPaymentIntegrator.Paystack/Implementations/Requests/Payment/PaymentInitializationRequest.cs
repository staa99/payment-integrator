using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentInitializationRequest : IPaymentInitializationRequest
    {
        public string Email { get; set; }

        public string Reference { get; set; }

        public string Currency { get; }

        public long Amount { get; set; }

        public string CallbackUrl { get; set; }

        public Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject();
            if (Reference != null)
            {
                obj["reference"] = Reference;
            }

            if (CallbackUrl != null)
            {
                obj["callback_url"] = CallbackUrl;
            }

            obj["email"] = Email;
            obj["amount"] = Amount;

            return obj.ToString();
        });

        public bool Validate (out Exception ex)
        {
            if (Amount <= 0)
            {
                ex = new ArgumentException("Amount must not be less than 0.", nameof(Amount));
                return false;
            }

            if (!Email.IsEmail())
            {
                ex = new FormatException("Email must be a valid email address");
                return false;
            }

            ex = null;
            return true;
        }
    }
}
