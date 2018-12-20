namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionPlanQueryRequest : IRequest
    {
        string[] References { get; }
    }
}