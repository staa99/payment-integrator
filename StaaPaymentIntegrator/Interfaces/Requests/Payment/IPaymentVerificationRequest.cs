namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Payment
{
    public interface IPaymentVerificationRequest : IRequest
    {
        string Reference { get; }
    }
}
