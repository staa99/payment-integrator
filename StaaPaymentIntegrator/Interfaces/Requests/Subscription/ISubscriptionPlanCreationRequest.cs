namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionPlanCreationRequest : IRequest
    {
        string Name { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}
