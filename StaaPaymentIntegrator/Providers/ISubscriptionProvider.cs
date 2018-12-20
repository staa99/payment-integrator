using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface ISubscriptionProvider
    {
        string Name { get; }

        string SubscriptionInitializationUrl { get; }

        Task InitializeSubscription (ISubscriptionInitializationRequest request);

        Task EnableSubscription (ISubscriptionEnableRequest request);

        Task DisableSubscription (ISubscriptionDisableRequest request);


    }
}
