using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment;
using Staaworks.PaymentIntegrator.Providers;
using Staaworks.PaymentIntegrator.Utilities;
using static Staaworks.PaymentIntegrator.Paystack.Utilities.RequestPreparations;

namespace Staaworks.PaymentIntegrator.Paystack
{
    public partial class Paystack : ITransferProvider
    {
        public string BankTransferRecipientCreationUrl { get; protected set; }
        public string BankTransferInitiationUrl { get; protected set; }


        public void InitializeTransfers (string recipientCreationUrl, string initiationUrl)
        {
            BankTransferRecipientCreationUrl = recipientCreationUrl ?? throw new ArgumentNullException(nameof(recipientCreationUrl), "The URL for transfer recipient creation must be provided to use the transfer APIs");
            BankTransferInitiationUrl = initiationUrl ?? throw new ArgumentNullException(nameof(initiationUrl), "The URL for transfer initiation must be provided to use the transfer APIs");
        }


        #region Create Transfer Recipient
        public async Task<IBankTransferRecipientCreationResponse> CreateTransferRecipient (IBankTransferRecipientCreationRequest request)
        {
            AssertReady(IsTransferAPIReady);
            return await Caller.Initialize("POST", PaymentChargeAuthorizationUrl, SecretKey, OnCreateTransferRecipientError, OnCreateTransferRecipientResult, await request.Serialize()).Call() as IBankTransferRecipientCreationResponse;
        }


        private async Task<IResponse> OnCreateTransferRecipientResult (string json, HttpStatusCode statusCode) => await SimpleResponseInitializer.Initialize<PaymentChargeAuthorizationResponse>(json);


        private Task<IResponse> OnCreateTransferRecipientError (Exception ex) => throw new Exception("An error occurred while initializing the charge request.", ex);
        #endregion


        #region Initiate Transfer
        public async Task<IBankTransferInitiationResponse> InitiateTransfer (IBankTransferInitiationRequest request)
        {
            AssertReady(IsTransferAPIReady);
            return await Caller.Initialize("POST", PaymentChargeAuthorizationUrl, SecretKey, OnInitiateTransferError, OnInitiateTransferResult, await request.Serialize()).Call() as IBankTransferInitiationResponse;
        }


        private async Task<IResponse> OnInitiateTransferResult (string json, HttpStatusCode statusCode) => await SimpleResponseInitializer.Initialize<PaymentChargeAuthorizationResponse>(json);


        private Task<IResponse> OnInitiateTransferError (Exception ex) => throw new Exception("An error occurred while initializing the charge request.", ex);
        #endregion


        private void IsTransferAPIReady ()
        {
            if (BankTransferInitiationUrl == null ||
                BankTransferRecipientCreationUrl == null)
            {
                throw new NotSupportedException("You must first call `InitializeTransfers` with non-null parameters to use the transfer APIs");
            }
        }
    }
}