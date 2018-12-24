using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentCheckAuthorizationRequest : IPaymentCheckAuthorizationRequest
    {
        public string AuthorizationReference { get; private set; }

        public long Amount { get; private set; }

        public string Email { get; private set; }

        public string Currency { get; private set; }

        public async Task<string> Serialize () => await Task.Run(() =>
        {
            var obj = new JObject();

            if (Currency != null)
            {
                obj["currency"] = Currency;
            }

            obj["authorization_code"] = AuthorizationReference;

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

            if (AuthorizationReference == null)
            {
                ex = new ArgumentNullException(nameof(AuthorizationReference));
                return false;
            }

            ex = null;
            return true;
        }
    }
}
