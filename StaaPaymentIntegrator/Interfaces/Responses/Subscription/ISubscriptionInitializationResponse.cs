namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionInitializationResponse : IResponse
    {
        string Reference { get; }
        string PlanReference { get; }
        long Amount { get; }
    }
}
