using System;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentVerificationRequest : IPaymentVerificationRequest
    {
        public PaymentVerificationRequest (string reference)
        {
            Reference = reference ?? throw new ArgumentNullException(nameof(reference));
        }

        public string Reference { get; }

        public Task<string> Serialize () => Task.FromResult($"/{Reference}");
        public bool Validate (out Exception ex)
        {
            ex = null;
            return true;
        }
    }
}