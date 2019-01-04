using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Banks
{
    public class BankAccountNameQueryRequest : BaseRequest, IBankAccountNameQueryRequest
    {
        private BankAccountNameQueryRequest () { }

        public string AccountNumber { get; private set; }

        public string BankReference { get; private set; }

        protected override void InitializeWithOptions (IDictionary<string, string> options)
        {
            BankReference = options[PAYSTACK_BANK_REFERENCE_KEY] ?? throw new ArgumentNullException(nameof(BankReference));
            AccountNumber = options[PAYSTACK_BANK_ACCOUNT_NUMBER_KEY] ?? throw new ArgumentNullException(nameof(AccountNumber));
        }


        public override Task<string> Serialize () => Task.FromResult($"?account_number={AccountNumber}&bank_code={BankReference}");
        public override bool Validate (out Exception ex)
        {
            if (AccountNumber == null)
            {
                ex = new ArgumentNullException(nameof(AccountNumber));
                return false;
            }

            if (BankReference == null)
            {
                ex = new ArgumentNullException(nameof(BankReference));
                return false;
            }

            ex = null;
            return true;
        }
    }
}
