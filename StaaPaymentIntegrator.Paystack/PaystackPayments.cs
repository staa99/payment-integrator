using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;
using Staaworks.PaymentIntegrator.Providers;
using static Staaworks.PaymentIntegrator.Paystack.Utilities.RequestPreparations;

namespace Staaworks.PaymentIntegrator.Paystack
{
    public partial class Paystack : IPaymentProvider
    {
        public string PaymentVerificationUrl { get; protected set; }

        public string PaymentInitializationUrl { get; protected set; }

        public string PaymentChargeAuthorizationUrl { get; protected set; }

        public string PaymentReauthorizationUrl { get; protected set; }

        public string PaymentCheckAuthorizationUrl { get; protected set; }

        public void InitializePayments (string verificationUrl, string initializationUrl, string chargeAuthorizationUrl, string reauthorizationUrl, string checkAuthorizationUrl)
        {
            PaymentVerificationUrl = verificationUrl;
            PaymentInitializationUrl = initializationUrl;
            PaymentChargeAuthorizationUrl = chargeAuthorizationUrl;
            PaymentReauthorizationUrl = reauthorizationUrl;
            PaymentCheckAuthorizationUrl = checkAuthorizationUrl;
        }

        #region Charge Authorization
        public async Task<IPaymentChargeAuthorizationResponse> ChargeAuthorization (IPaymentChargeAuthorizationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await PaystackCall<IPaymentChargeAuthorizationResponse>.Post(PaymentInitializationUrl, SecretKey, await request.Serialize(), OnChargeAuthorizationError, OnChargeAuthorizationResult);
        }

        private async Task<IPaymentChargeAuthorizationResponse> OnChargeAuthorizationResult (string json, HttpStatusCode statusCode)
        {
            var response = new PaymentChargeAuthorizationResponse();
            await response.Parse(json);
            return response;
        }

        private Task<IPaymentChargeAuthorizationResponse> OnChargeAuthorizationError (Exception ex) => throw new Exception("An error occurred while initializing the request.", ex);
        #endregion


        #region Check Authorization
        public Task<IPaymentAuthorizationCheckRequest> CheckAuthorization (IPaymentAuthorizationCheckRequest request) => throw new NotImplementedException();
        #endregion


        #region Make Payment
        public async Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await PaystackCall<IPaymentInitializationResponse>.Post(PaymentInitializationUrl, SecretKey, await request.Serialize(), OnMakePaymentError, OnMakePaymentResult);
        }

        private async Task<IPaymentInitializationResponse> OnMakePaymentResult (string json, HttpStatusCode statusCode)
        {
            var response = new PaymentInitializationResponse();
            await response.Parse(json);
            return response;
        }

        private Task<IPaymentInitializationResponse> OnMakePaymentError (Exception ex) => throw new Exception("An error occurred while initializing the request.", ex);
        #endregion


        #region Request Reauthorization
        public Task<IPaymentReauthorizationRequest> RequestReauthorization (IPaymentReauthorizationRequest request) => throw new NotImplementedException();
        #endregion

        #region Verify Payment
        public Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return PaystackCall<IPaymentVerificationResponse>.Get(PaymentVerificationUrl + request.Serialize().Result, SecretKey, OnVerifyPaymentError, OnVerifyPaymentResult);
        }

        private async Task<IPaymentVerificationResponse> OnVerifyPaymentResult (string json, HttpStatusCode statusCode)
        {
            var response = new PaymentVerificationResponse();
            await response.Parse(json);
            return response;
        }

        private Task<IPaymentVerificationResponse> OnVerifyPaymentError (Exception ex) => throw new Exception("An error occurred while verifying the request.", ex);
        #endregion

        private void IsPaymentAPIReady ()
        {
            if (PaymentVerificationUrl == null ||
                PaymentInitializationUrl == null ||
                PaymentChargeAuthorizationUrl == null ||
                PaymentCheckAuthorizationUrl == null ||
                PaymentReauthorizationUrl == null)
            {
                throw new NotSupportedException("You must first call `InitializePayments` with non-null parameters to use the payment APIs");
            }
        }
    }
}