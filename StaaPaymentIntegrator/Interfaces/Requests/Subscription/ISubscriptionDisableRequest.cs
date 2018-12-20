namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionDisableRequest : IRequest
    {
        string Reference { get; }
    }
}
