using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.SubscriptionInitialization;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface ISubscriptionProvider
    {
        string Name { get; set; }

        string SubscriptionInitializationUrl { get; set; }

        Task InitializeSubscription (ISubscriptionInitializationRequest request);
    }
}
