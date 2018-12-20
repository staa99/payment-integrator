using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;

namespace Staaworks.PaymentIntegrator.Providers
{
    public abstract class BasePaymentProvider : IPaymentProvider
    {
        public string PaymentVerificationUrl { get; protected set; }

        public string PaymentInitializationUrl { get; protected set; }

        public string SecretKey { get; protected set; }

        public string Name { get; protected set; }

        public abstract Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request);

        public abstract Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request);
    }
}
