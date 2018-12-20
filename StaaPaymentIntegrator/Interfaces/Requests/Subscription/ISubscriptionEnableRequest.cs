namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionEnableRequest : IRequest
    {
        string Reference { get; }
    }
}