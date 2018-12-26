namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentChargeAuthorizationResponse : IResponse
    {
        bool Successful { get; }

        string AuthorizationReference { get; }

        string Reference { get; }

        long Amount { get; }

        string Currency { get; }
    }
}
