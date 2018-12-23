namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentVerificationResponse : IResponse
    {
        bool Successful { get; }

        string AuthorizationReference { get; }

        string Reference { get; }

        string Message { get; }

        long Amount { get; }
    }
}
