using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentVerification;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentVerification;

namespace Staaworks.PaymentIntegrator.Providers
{
    /**
     * Base interface for all payment providers supported by the platform, provides methods for making and verifying payments
     */
    public interface IPaymentProvider
    {
        string Name { get; }

        string VerificationUrl { get; }
        
        string InitializationUrl { get; }
        
        string BanksListUrl { get; }
        
        string CallbackUrl { get; }
        
        string SecretKey { get; }
        
        Task<IBanksResponse> GetBanks ();
        
        Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest initializationRequest);
        
        Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest verificationRequest);
    }
}
