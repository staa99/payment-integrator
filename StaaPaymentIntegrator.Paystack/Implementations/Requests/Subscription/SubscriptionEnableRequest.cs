using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Subscription
{
    public class SubscriptionEnableRequest : BaseRequest, ISubscriptionEnableRequest
    {
        public string Reference { get; private set; }
        public string EmailToken { get; private set; }

        public override Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject
            {
                ["code"] = Reference,
                ["token"] = EmailToken
            };

            return obj.ToString();
        });


        public override bool Validate (out Exception ex)
        {
            if (Reference == null)
            {
                ex = new ArgumentNullException(nameof(Reference));
                return false;
            }

            if (EmailToken == null)
            {
                ex = new ArgumentNullException(nameof(EmailToken));
                return false;
            }

            ex = null;
            return true;
        }


        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            Reference = options[PAYSTACK_SUBSCRIPTION_CODE_KEY] ?? throw new ArgumentNullException(nameof(Reference));
            EmailToken = options[PAYSTACK_EMAIL_TOKEN_KEY] ?? throw new ArgumentNullException(nameof(EmailToken));
        }
    }
}
