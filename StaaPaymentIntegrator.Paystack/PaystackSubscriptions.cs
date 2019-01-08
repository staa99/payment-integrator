using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;
using Staaworks.PaymentIntegrator.Providers;

namespace Staaworks.PaymentIntegrator.Paystack
{
    public partial class Paystack : ISubscriptionProvider
    {
        public string SubscriptionInitializationUrl { get; protected set; }
        public string SubscriptionActivationUrl { get; protected set; }
        public string SubscriptionDeactivationUrl { get; protected set; }
        public string SubscriptionPlanCreationUrl { get; protected set; }
        public string SubscriptionPlanQueryUrl { get; protected set; }
        public string SubscriptionQueryUrl { get; protected set; }


        public void InitializeSubscriptions (string initializationUrl, string activationUrl, string deactivationUrl, string planCreationUrl, string planQueryUrl, string queryUrl)
        {
            SubscriptionInitializationUrl = initializationUrl ?? throw new ArgumentNullException(nameof(initializationUrl), "The URL for subscription initialization must be provided to use the subscription APIs");
            SubscriptionActivationUrl = activationUrl ?? throw new ArgumentNullException(nameof(activationUrl), "The URL for subscription activation must be provided to use the subscription APIs");
            SubscriptionDeactivationUrl = deactivationUrl ?? throw new ArgumentNullException(nameof(deactivationUrl), "The URL for subscription deactivation must be provided to use the subscription APIs");
            SubscriptionPlanCreationUrl = planCreationUrl ?? throw new ArgumentNullException(nameof(planCreationUrl), "The URL for plan creation must be provided to use the subscription APIs");
            SubscriptionPlanQueryUrl = planQueryUrl ?? throw new ArgumentNullException(nameof(planQueryUrl), "The URL for subscription plan queries must be provided to use the subscription APIs");
            SubscriptionQueryUrl = queryUrl ?? throw new ArgumentNullException(nameof(queryUrl), "The URL for subscription queries must be provided to use the subscription APIs");
        }

        #region
        public Task<ISubscriptionPlanCreationResponse> CreateSubscriptionPlan (ISubscriptionPlanCreationRequest request) => throw new NotImplementedException();
        #endregion


        #region
        public Task<ISubscriptionDisableRequest> DisableSubscription (ISubscriptionDisableRequest request) => throw new NotImplementedException();
        #endregion


        #region
        public Task<ISubscriptionEnableRequest> EnableSubscription (ISubscriptionEnableRequest request) => throw new NotImplementedException();
        #endregion


        #region
        public Task<ISubscriptionQueryResponse> GetSubscriptions (ISubscriptionQueryRequest request) => throw new NotImplementedException();
        #endregion


        #region
        public Task<ISubscriptionInitializationResponse> InitializeSubscription (ISubscriptionInitializationRequest request) => throw new NotImplementedException();
        #endregion


        #region
        public Task<ISubscriptionPlanQueryResponse> QuerySubscriptionPlans (ISubscriptionPlanQueryRequest request) => throw new NotImplementedException();
        #endregion


        private void IsSubscriptionAPIReady ()
        {
            if (SubscriptionInitializationUrl == null ||
                SubscriptionActivationUrl == null ||
                SubscriptionDeactivationUrl == null ||
                SubscriptionPlanCreationUrl == null ||
                SubscriptionPlanQueryUrl == null ||
                SubscriptionQueryUrl == null)
            {
                throw new NotSupportedException("You must first call `InitializeSubscriptions` with non-null parameters to use the subscriptions APIs");
            }
        }
    }
}