namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Banks
{
    public interface IBankAccountNameQueryRequest : IRequest
    {
        string AccountNumber { get; }
        string BankReference { get; }
    }
}