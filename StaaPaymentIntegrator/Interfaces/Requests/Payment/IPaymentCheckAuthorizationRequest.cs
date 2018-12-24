namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Payment
{
    /// <summary>
    /// This contract defines the outer structure of requests to determine if the customer has enough money to allow a transaction to be authorized.
    /// </summary>
    public interface IPaymentCheckAuthorizationRequest : IRequest
    {
        string AuthorizationReference { get; }
        string Amount { get; }
        string Email { get; }
        string Currency { get; }
    }
}
