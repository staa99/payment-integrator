using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Subscription
{
    public class SubscriptionInitializationRequest : BaseRequest, ISubscriptionInitializationRequest
    {
        public string CustomerReference { get; private set; }
        public string PlanReference { get; private set; }
        public DateTime StartDate { get; private set; } = DateTime.Now;
        public override Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject
            {
                ["customer"] = CustomerReference,
                ["plan"] = PlanReference,
                ["start_date"] = StartDate
            };

            return obj.ToString();
        });


        public override bool Validate (out Exception ex)
        {
            if (CustomerReference == null)
            {
                ex = new ArgumentNullException(nameof(CustomerReference));
                return false;
            }

            if (PlanReference == null)
            {
                ex = new ArgumentNullException(nameof(PlanReference));
                return false;
            }

            ex = null;
            return true;
        }


        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            CustomerReference = options[PAYSTACK_CUSTOMER_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(CustomerReference));
            PlanReference = options[PAYSTACK_PLAN_CODE_KEY] ?? throw new ArgumentNullException(nameof(PlanReference));
            StartDate = DateTime.Parse(options[PAYSTACK_START_DATE_KEY] ?? throw new ArgumentNullException(nameof(StartDate)));
        }
    }
}
