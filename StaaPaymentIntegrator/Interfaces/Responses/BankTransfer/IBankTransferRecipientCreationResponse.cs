namespace Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer
{
    public interface IBankTransferRecipientCreationResponse : IResponse
    {
        string RecipientReference { get; }
        string AccountName { get; }
        string BankName { get; }
        string BankReference { get; }
        string RecipientName { get; }
        string AccountNumber { get; }
    }
}