using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface ISubscriptionProvider : IProvider
    {
        string SubscriptionInitializationUrl { get; }

        Task<ISubscriptionInitializationResponse> InitializeSubscription (ISubscriptionInitializationRequest request);

        Task<ISubscriptionEnableRequest> EnableSubscription (ISubscriptionEnableRequest request);

        Task<ISubscriptionDisableRequest> DisableSubscription (ISubscriptionDisableRequest request);

        Task<ISubscriptionPlanCreationResponse> CreateSubscriptionPlan (ISubscriptionPlanCreationRequest request);

        Task<ISubscriptionPlanQueryResponse> QuerySubscriptionPlans (ISubscriptionPlanQueryRequest request);

        Task<ISubscriptionQueryResponse> GetSubscriptions (ISubscriptionQueryRequest request);
    }
}