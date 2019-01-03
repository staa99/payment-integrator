using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.BankTransfer;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.BankTransfer
{
    public class BankTransferRecipientCreationRequest : BaseRequest, IBankTransferRecipientCreationRequest
    {
        public string BankReference { get; private set; }

        public string AccountNumber { get; private set; }

        public string RecipientName { get; private set; }

        public string Currency { get; private set; }

        public long Amount { get; private set; }

        public string Description { get; private set; }
        
        public override Task<string> Serialize () => throw new NotImplementedException();
        public override bool Validate (out Exception ex) => throw new NotImplementedException();

        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            BankReference = options[PAYSTACK_BANK_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(BankReference));
            AccountNumber = options[PAYSTACK_BANK_ACCOUNT_NUMBER_KEY] ?? throw new ArgumentNullException(nameof(AccountNumber));
            AccountNumber = options[PAYSTACK_BANK_ACCOUNT_NUMBER_KEY] ?? throw new ArgumentNullException(nameof(AccountNumber));
        }
    }
}
