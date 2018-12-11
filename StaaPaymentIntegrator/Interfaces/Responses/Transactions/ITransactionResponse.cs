namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions
{
    public interface ITransactionResponse
    {
        string TransactionRef { get; }

        string TransactionContent { get; }
    }
}
