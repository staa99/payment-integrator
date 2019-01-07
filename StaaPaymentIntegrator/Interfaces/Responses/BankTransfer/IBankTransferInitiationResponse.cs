namespace Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer
{
    public interface IBankTransferInitiationResponse : IResponse
    {
        string TransferReference { get; }
        long Amount { get; }
        string Currency { get; }
    }
}