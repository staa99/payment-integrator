namespace Staaworks.PaymentIntegrator.Interfaces.Responses
{
    public interface ITransactionResponse
    {
        string TransactionRef { get; }

        string TransactionContent { get; }
    }
}
