namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBankAccountNameQueryResponse: IResponse
    {
        string AccountName { get; }
        string AccountNumber { get; }
    }
}
