namespace Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer
{
    public interface IBankTransferRecipientCreationRequest : IRequest
    {
        string BankReference { get; }
        string AccountNumber { get; }
        string RecipientName { get; }
        string Currency { get; }
        string Amount { get; }
        string Description { get; }
    }
}