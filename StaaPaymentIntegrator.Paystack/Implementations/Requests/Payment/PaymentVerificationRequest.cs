using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentVerificationRequest : BaseRequest, IPaymentVerificationRequest
    {
        public string Reference { get; private set; }


        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            if (options.TryGetValue(PAYSTACK_VERIFICATION_REFERENCE_KEY, out var reference))
            {
                Reference = reference;
            }
        }

        public override Task<string> Serialize () => Task.FromResult($"/{Reference}");
        public override bool Validate (out Exception ex)
        {
            if (Reference == null)
            {
                ex = new ArgumentNullException(nameof(Reference));
                return false;
            }

            ex = null;
            return true;
        }
    }
}