using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;

namespace Staaworks.PaymentIntegrator.Providers
{
    /**
     * Base interface for all payment providers supported by the platform, provides methods for making and verifying payments
     */
    public interface IPaymentProvider : IProvider
    {
        string PaymentVerificationUrl { get; }

        string PaymentInitializationUrl { get; }

        Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request);

        Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request);
    }
}
