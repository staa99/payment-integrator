using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment;
using Staaworks.PaymentIntegrator.Providers;
using Staaworks.PaymentIntegrator.Utilities;
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
            return await Caller.Initialize("POST", PaymentChargeAuthorizationUrl, SecretKey, OnChargeAuthorizationError, OnChargeAuthorizationResult, await request.Serialize()).Call() as IPaymentChargeAuthorizationResponse;
        }

        private async Task<IResponse> OnChargeAuthorizationResult (string json, HttpStatusCode statusCode)
        {
            return await SimpleResponseInitializer.Initialize<PaymentChargeAuthorizationResponse>(json);
        }

        private Task<IResponse> OnChargeAuthorizationError (Exception ex) => throw new Exception("An error occurred while initializing the charge request.", ex);
        #endregion


        #region Check Authorization
        public async Task<IPaymentCheckAuthorizationResponse> CheckAuthorization (IPaymentCheckAuthorizationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await Caller.Initialize("POST", PaymentCheckAuthorizationUrl, SecretKey, OnCheckAuthorizationError, OnCheckAuthorizationResult, await request.Serialize()).Call() as IPaymentCheckAuthorizationResponse;
        }

        private async Task<IResponse> OnCheckAuthorizationResult (string json, HttpStatusCode statusCode)
        {
            return await SimpleResponseInitializer.Initialize<PaymentCheckAuthorizationResponse>(json);
        }

        private Task<IResponse> OnCheckAuthorizationError (Exception ex) => throw new Exception("An error occurred while initializing the request.", ex);
        #endregion


        #region Make Payment
        public async Task<IPaymentInitializationResponse> MakePayment (IPaymentInitializationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await Caller.Initialize("POST", PaymentInitializationUrl, SecretKey, OnMakePaymentError, OnMakePaymentResult, await request.Serialize()).Call() as IPaymentInitializationResponse;
        }

        private async Task<IResponse> OnMakePaymentResult (string json, HttpStatusCode statusCode)
        {
            return await SimpleResponseInitializer.Initialize<PaymentInitializationResponse>(json);
        }

        private Task<IResponse> OnMakePaymentError (Exception ex) => throw new Exception("An error occurred while initializing the payment.", ex);
        #endregion


        #region Request Reauthorization
        public async Task<IPaymentReauthorizationResponse> RequestReauthorization (IPaymentReauthorizationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await Caller.Initialize("POST", PaymentReauthorizationUrl, SecretKey, OnReauthorizationError, OnReauthorizationResult, await request.Serialize()).Call() as IPaymentReauthorizationResponse;
        }

        private async Task<IResponse> OnReauthorizationResult (string json, HttpStatusCode statusCode)
        {
            return await SimpleResponseInitializer.Initialize<PaymentReauthorizationResponse>(json);
        }

        private Task<IResponse> OnReauthorizationError (Exception ex) => throw new Exception("An error occurred while initializing the request.", ex);
        #endregion

        #region Verify Payment
        public async Task<IPaymentVerificationResponse> VerifyPayment (IPaymentVerificationRequest request)
        {
            AssertReady(IsPaymentAPIReady);
            return await Caller.Initialize("GET", PaymentVerificationUrl + request.Serialize().Result, SecretKey, OnVerifyPaymentError, OnVerifyPaymentResult).Call() as IPaymentVerificationResponse;
        }

        private async Task<IResponse> OnVerifyPaymentResult (string json, HttpStatusCode statusCode)
        {
            return await SimpleResponseInitializer.Initialize<PaymentVerificationResponse>(json);
        }

        private Task<IResponse> OnVerifyPaymentError (Exception ex) => throw new Exception("An error occurred while verifying the request.", ex);
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