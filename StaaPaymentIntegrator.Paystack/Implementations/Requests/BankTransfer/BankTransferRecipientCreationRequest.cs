using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.BankTransfer
{
    public class BankTransferRecipientCreationRequest : BaseRequest, IBankTransferRecipientCreationRequest
    {
        public string BankReference { get; private set; }

        public string AccountNumber { get; private set; }

        public string RecipientName { get; private set; }

        public string Currency { get; private set; } = "NGN";

        public string Description { get; private set; }

        public string Metadata { get; private set; }

        public override Task<string> Serialize () => Task.Run(() =>
        {
            var obj = new JObject
            {
                ["name"] = RecipientName,
                ["bank_code"] = BankReference,
                ["account_number"] = AccountNumber,
                ["currency"] = Currency
            };

            if (Description != null)
            {
                obj["description"] = Description;
            }

            if (Metadata != null)
            {
                obj["metadata"] = JObject.Parse(Metadata);
            }

            return obj.ToString();
        });

        public override bool Validate (out Exception ex)
        {
            if (BankReference == null)
            {
                ex = new ArgumentNullException(BankReference);
                return false;
            }

            if (AccountNumber == null)
            {
                ex = new ArgumentNullException(AccountNumber);
                return false;
            }

            if (RecipientName == null)
            {
                ex = new ArgumentNullException(RecipientName);
                return false;
            }

            ex = null;
            return true;
        }

        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            BankReference = options[PAYSTACK_BANK_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(BankReference));
            AccountNumber = options[PAYSTACK_BANK_ACCOUNT_NUMBER_KEY] ?? throw new ArgumentNullException(nameof(AccountNumber));
            RecipientName = options[PAYSTACK_BANK_RECIPIENT_NAME_KEY] ?? throw new ArgumentNullException(nameof(RecipientName));

            if (options.TryGetValue(PAYSTACK_CURRENCY_KEY, out var currency))
            {
                Currency = currency;
            }

            if (options.TryGetValue(PAYSTACK_DESCRIPTION_KEY, out var description))
            {
                Description = description;
            }

            if (options.TryGetValue(PAYSTACK_METADATA_KEY, out var metadata))
            {
                Metadata = metadata;
            }
        }
    }
}
