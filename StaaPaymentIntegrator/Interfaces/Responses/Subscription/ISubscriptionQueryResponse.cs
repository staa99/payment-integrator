namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionQueryResponse : IResponse
    {
        ISubscriptionDetailsResponse[] Subscriptions { get; }
    }
}
