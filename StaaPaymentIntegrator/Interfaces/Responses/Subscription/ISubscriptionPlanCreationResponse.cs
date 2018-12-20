namespace Staaworks.PaymentIntegrator.Interfaces.Responses.SubscriptionPlan
{
    public interface ISubscriptionPlanCreationResponse
    {
        string Status { get; }
        string Reference { get; }
    }
}
