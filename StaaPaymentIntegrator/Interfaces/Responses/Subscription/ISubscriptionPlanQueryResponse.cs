namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionPlanQueryResponse : IResponse
    {
        ISubscriptionPlanQueryItem[] Plans { get; }
    }

    public interface ISubscriptionPlanQueryItem
    {
        int ActiveSubscriptionCount { get; }
        int TotalSubscriptionCount { get; }
        string Reference { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}
