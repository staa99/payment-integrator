namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionPlanCreationRequest : IRequest
    {
        string Reference { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}
