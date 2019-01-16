namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionPlanDetailsRequest : IRequest
    {
        string Reference { get; }
    }
}