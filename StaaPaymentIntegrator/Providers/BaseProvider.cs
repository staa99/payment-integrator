using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentVerification;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentVerification;

namespace Staaworks.PaymentIntegrator.Providers
{
    public abstract class BaseProvider : IPaymentProvider
    {
        public string VerificationUrl  { get; protected set; }

        public string InitializationUrl  { get; protected set; }

        public string BanksListUrl { get; protected set; }

        public string CallbackUrl  { get; protected set; }

        public string SecretKey  { get; protected set; }

        public string Name { get; protected set; }

        public abstract Task<IBanksResponse> GetBanks ();

        public abstract Task<IPaymentInitializationResponse> MakePayment(IPaymentInitializationRequest initializationRequest);

        public abstract Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest verificationRequest);
    }
}
