namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription
{
    public interface ISubscriptionDetailsResponse: IResponse
    {
        int Quantity { get; }
        long Amount { get; }
        string Reference { get; }
        string PlanReference { get; }
    }
}