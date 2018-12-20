namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionInitializationResponse : IResponse
    {
        string Reference { get; }
        long Amount { get; }
    }
}
