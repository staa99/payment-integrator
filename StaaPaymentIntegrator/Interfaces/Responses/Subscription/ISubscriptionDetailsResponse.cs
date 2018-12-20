namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionDetailsResponse
    {
        string Status { get; }
        int Quantity { get; }
        long Amount { get; }
        string Currency { get; }
        string Reference { get; }
        string PlanReference { get; }
    }
}