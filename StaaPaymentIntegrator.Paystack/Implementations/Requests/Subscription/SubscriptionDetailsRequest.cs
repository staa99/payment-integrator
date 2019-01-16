using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Subscription
{
    public class SubscriptionDetailsRequest : BaseRequest, ISubscriptionDetailsRequest
    {
        public string Reference { get; private set; }


        public override Task<string> Serialize () => Task.FromResult($"/{Reference}");


        public override bool Validate (out Exception ex)
        {
            if (Reference == null)
            {
                ex = new ArgumentNullException(nameof(Reference));
                return false;
            }

            ex = null;
            return true;
        }


        protected override void InitializeWithOptions (IDictionary<string, string> options) =>
            Reference = options[PAYSTACK_PLAN_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(Reference));
    }
}
