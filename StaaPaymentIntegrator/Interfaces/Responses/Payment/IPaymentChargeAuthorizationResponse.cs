namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentChargeAuthorizationResponse : IResponse
    {
        bool Successful { get; }

        string AuthorizationReference { get; }

        string Reference { get; }

        string Message { get; }

        long Amount { get; }

        string Currency { get; }
    }
}
