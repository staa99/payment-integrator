using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.Payment;

namespace Staaworks.PaymentIntegrator.Providers
{
    /**
     * Base interface for all payment providers supported by the platform, provides methods for making and verifying payments
     */
    public interface IPaymentProvider
    {
        string Name { get; }

        string PaymentVerificationUrl { get; }

        string PaymentInitializationUrl { get; }

        string CallbackUrl { get; }

        string SecretKey { get; }


        Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request);

        Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request);
    }
}
