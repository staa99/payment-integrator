namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionListResponse : IResponse
    {
        ISubscriptionDetailsResponse[] Subscriptions { get; }
    }
}
