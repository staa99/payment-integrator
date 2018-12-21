namespace Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer
{
    public interface IBankTransferInitiationResponse : IResponse
    {
        string Reference { get; }
        string Amount { get; }
        string Currency { get; }
        string RecipientReference { get; }
    }
}