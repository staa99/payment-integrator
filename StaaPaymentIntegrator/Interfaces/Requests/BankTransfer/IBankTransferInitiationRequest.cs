namespace Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer
{
    public interface IBankTransferInitiationRequest : IRequest
    {
        string Reference { get; }
        long Amount { get; }
        string Currency { get; }
        string RecipientReference { get; }
    }
}