using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer;
using Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface ITransferProvider: IProvider
    {
        string BankTransferRecipientCreationUrl { get; }
        string BankTransferInitiationUrl { get; }

        Task<IBankTransferRecipientCreationResponse> CreateTransferRecipient (IBankTransferRecipientCreationRequest request);

        Task<IBankTransferInitiationResponse> InitiateTransfer (IBankTransferInitiationRequest request);
    }
}
