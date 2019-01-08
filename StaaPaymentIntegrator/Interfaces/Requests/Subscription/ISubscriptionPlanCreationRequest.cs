namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionPlanCreationRequest : IRequest
    {
        string Name { get; }
        string Reference { get; }
        int CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}
