namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBankAccountNameQueryResponse
    {
        string AccountName { get; }
        string AccountNumber { get; }
    }
}
