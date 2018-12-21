using System;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.PaymentInitialization;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Providers;

namespace StaaPaymentIntegrator.Paystack
{
    public partial class Paystack : IPaymentProvider
    {
        public string PaymentVerificationUrl => throw new NotImplementedException();

        public string PaymentInitializationUrl => throw new NotImplementedException();

        public Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request) => throw new NotImplementedException();
        public Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request) => throw new NotImplementedException();
    }
}
