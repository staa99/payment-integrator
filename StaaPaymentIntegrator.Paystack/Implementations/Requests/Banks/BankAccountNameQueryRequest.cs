using System;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Banks
{
    public class BankAccountNameQueryRequest : IBankAccountNameQueryRequest
    {
        public BankAccountNameQueryRequest (string accountNumber, string bankReference)
        {
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            BankReference = bankReference ?? throw new ArgumentNullException(nameof(bankReference));
        }

        public string AccountNumber { get; }

        public string BankReference { get; }

        public Task<string> Serialize () => Task.FromResult($"?account_number={AccountNumber}&bank_code={BankReference}");
        public bool Validate (out Exception ex)
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
