namespace Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer
{
    public interface IBankTransferInitiationRequest : IRequest
    {
        string Reference { get; }
        string Amount { get; }
        string Currency { get; }
        string RecipientReference { get; }
    }
}