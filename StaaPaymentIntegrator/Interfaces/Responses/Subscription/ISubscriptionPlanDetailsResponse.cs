namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionPlanDetailsResponse : IResponse
    {
        int ActiveSubscriptionCount { get; }
        int TotalSubscriptionCount { get; }
        string Reference { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}