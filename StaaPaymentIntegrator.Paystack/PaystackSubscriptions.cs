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
        public string SubscriptionInitializationUrl => throw new NotImplementedException();

        public string SubscriptionActivationUrl => throw new NotImplementedException();

        public string SubscriptionDeactivationUrl => throw new NotImplementedException();

        public string SubscriptionPlanCreationUrl => throw new NotImplementedException();

        public string SubscriptionPlanQueryUrl => throw new NotImplementedException();

        public string SubscriptionQueryUrl => throw new NotImplementedException();


        public void InitializeSubscriptions (string recipientCreationUrl, string initiationUrl)
        {
            BankTransferRecipientCreationUrl = recipientCreationUrl;
            BankTransferInitiationUrl = initiationUrl;
        }


        public Task<ISubscriptionPlanCreationResponse> CreateSubscriptionPlan (ISubscriptionPlanCreationRequest request) => throw new NotImplementedException();
        public Task<ISubscriptionDisableRequest> DisableSubscription (ISubscriptionDisableRequest request) => throw new NotImplementedException();
        public Task<ISubscriptionEnableRequest> EnableSubscription (ISubscriptionEnableRequest request) => throw new NotImplementedException();
        public Task<ISubscriptionQueryResponse> GetSubscriptions (ISubscriptionQueryRequest request) => throw new NotImplementedException();
        public Task<ISubscriptionInitializationResponse> InitializeSubscription (ISubscriptionInitializationRequest request) => throw new NotImplementedException();
        public Task<ISubscriptionPlanQueryResponse> QuerySubscriptionPlans (ISubscriptionPlanQueryRequest request) => throw new NotImplementedException();

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
