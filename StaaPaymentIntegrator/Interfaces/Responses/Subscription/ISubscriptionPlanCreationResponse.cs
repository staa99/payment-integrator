namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionPlanCreationResponse : IResponse
    {
        string Reference { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
    }
}