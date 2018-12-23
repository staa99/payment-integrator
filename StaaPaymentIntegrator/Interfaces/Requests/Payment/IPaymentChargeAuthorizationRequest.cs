namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Payment
{
    /// <summary>
    /// This charges the user if possible. The user must have already authorized a transaction before this.
    /// </summary>
    public interface IPaymentChargeAuthorizationRequest : IRequest
    {
        string Email { get; }
        string Reference { get; }
        long Amount { get; }
        string Currency { get; }
        string AuthorizationReference { get; }
    }
}
