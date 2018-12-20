namespace Staaworks.PaymentIntegrator.Interfaces.Responses
{
    public interface ITransactionResponse: IResponse
    {
        string TransactionRef { get; }

        string TransactionContent { get; }
    }
}
