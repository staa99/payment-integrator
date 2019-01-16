using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Subscription
{
    public class SubscriptionPlanCreationRequest : BaseRequest, ISubscriptionPlanCreationRequest
    {
        public string Reference { get; private set; }

        public string Name => Reference;

        public int CycleDurationInHours { get; private set; }

        public long Amount { get; private set; }

        public string Currency { get; private set; } = "NGN";

        public override Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject
            {
                ["name"] = Reference,
                ["amount"] = Amount,
                ["currency"] = Currency
            };

            if (IntervalMap.TryGetValue(CycleDurationInHours, out var interval))
            {
                obj["interval"] = interval;
            }
            else
            {
                throw new ArgumentException("The interval must be one of " + string.Join(", ", IntervalMap.Values));
            }

            return obj.ToString();
        });


        public override bool Validate (out Exception ex)
        {
            if (Amount <= 0)
            {
                ex = new ArgumentException("Amount must not be less than 0.", nameof(Amount));
                return false;
            }

            if (Reference == null)
            {
                ex = new ArgumentException("The plan name is required.");
                return false;
            }

            if (Array.IndexOf(new[] { 1, 24, 168, 720, 8760 }, CycleDurationInHours) == -1)
            {
                ex = new ArgumentException("The interval is required and must be one of " + string.Join(", ", IntervalMap.Values));
            }

            ex = null;
            return true;
        }


        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            Reference = options[PAYSTACK_PLAN_NAME_KEY] ?? throw new ArgumentNullException(nameof(Reference));
            Amount = Convert.ToInt64(options[PAYSTACK_AMOUNT_KEY] ?? throw new ArgumentNullException(nameof(Amount)));

            if (options.TryGetValue(PAYSTACK_CURRENCY_KEY, out var currency))
            {
                Currency = currency;
            }

            CycleDurationInHours = IntervalMap.FirstOrDefault(p => p.Value == options[PAYSTACK_PLAN_INTERVAL_KEY]).Key;
        }
    }
}