namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Payment
{
    /// <summary>
    /// This attempts to lead the user to complete a payment after which an authorization is possible. If the user pays successfully, this allows the system to charge the user without physical presence.
    /// </summary>
    public interface IPaymentReauthorizationRequest : IRequest
    {
        string Email { get; }
        string Reference { get; }
        long Amount { get; }
        string Currency { get; }
        string AuthorizationReference { get; }
    }
}