using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.BankTransfer
{
    public class BankTransferInitiationRequest : BaseRequest, IBankTransferInitiationRequest
    {
        public string Source { get; private set; } = "balance";

        public string Reference { get; private set; }

        public long Amount { get; private set; }

        public string Currency { get; private set; } = "NGN";

        public string RecipientReference { get; private set; }

        public string Reason { get; private set; }

        public override Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject
            {
                ["currency"] = Currency,
                ["amount"] = Amount,
                ["source"] = Source,
                ["recipient"] = RecipientReference
            };


            if (Reason != null)
            {
                obj["reason"] = Reason;
            }

            if (Reference != null)
            {
                obj["reference"] = JObject.Parse(Reference);
            }

            return obj.ToString();
        });

        public override bool Validate (out Exception ex)
        {
            if (Amount <= 0)
            {
                ex = new ArgumentException("The amount must not be zero or less", nameof(Amount));
                return false;
            }

            if (RecipientReference == null)
            {
                ex = new ArgumentNullException(nameof(RecipientReference));
            }

            ex = null;
            return true;
        }

        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            Amount = Convert.ToInt64(options[PAYSTACK_AMOUNT_KEY] ?? throw new ArgumentNullException(nameof(Amount)));
            RecipientReference = options[PAYSTACK_TRANSFER_RECIPIENT_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(RecipientReference));

            if (options.TryGetValue(PAYSTACK_CURRENCY_KEY, out var currency))
            {
                Currency = currency;
            }

            if (options.TryGetValue(PAYSTACK_TRANSFER_SOURCE_KEY, out var source))
            {
                Source = source;
            }

            if (options.TryGetValue(PAYSTACK_TRANSFER_REASON_KEY, out var reason))
            {
                Reason = reason;
            }

            if (options.TryGetValue(PAYSTACK_TRANSFER_REFERENCE_KEY, out var reference))
            {
                Reference = reference;
            }
        }
    }
}