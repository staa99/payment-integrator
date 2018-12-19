namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.SubscriptionPlan
{
    public interface ISubscriptionPlanCreationResponse
    {
        string Status { get; }
        string Reference { get; }
    }
}
