using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentReauthorizationRequest : BaseRequest, IPaymentReauthorizationRequest
    {
        public string Email { get; set; }

        public string Reference { get; set; }

        public long Amount { get; set; }

        public string Currency { get; set; }

        public string AuthorizationReference { get; set; }

        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            Email = options[PAYSTACK_EMAIL_KEY] ?? throw new ArgumentNullException(nameof(Email));
            Amount = Convert.ToInt64(options[PAYSTACK_AMOUNT_KEY] ?? throw new ArgumentNullException(nameof(Amount)));
            AuthorizationReference = options[PAYSTACK_AUTHORIZATION_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(AuthorizationReference));
        
            if (options.TryGetValue(PAYSTACK_CURRENCY_KEY, out var currency))
            {
                Currency = currency;
            }

            if (options.TryGetValue(PAYSTACK_REAUTHORIZATION_REFERENCE_KEY, out var reference))
            {
                Reference = reference;
            }
        }

        public override async Task<string> Serialize () => await Task.Run(() =>
        {
            var obj = new JObject();
            if (Reference != null)
            {
                obj["reference"] = Reference;
            }

            if (Currency != null)
            {
                obj["currency"] = Currency;
            }

            obj["authorization_code"] = AuthorizationReference;

            obj["email"] = Email;
            obj["amount"] = Amount;

            return obj.ToString();
        });

        public override bool Validate (out Exception ex)
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
