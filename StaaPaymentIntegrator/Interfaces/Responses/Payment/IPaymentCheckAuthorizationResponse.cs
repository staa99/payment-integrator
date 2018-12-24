namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentCheckAuthorizationResponse : IResponse
    {
        long Amount { get; }

        string Currency { get; }

        string Message { get; }
    }
}
