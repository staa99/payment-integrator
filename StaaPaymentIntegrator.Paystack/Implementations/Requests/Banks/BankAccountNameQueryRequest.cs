using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;

namespace StaaPaymentIntegrator.Paystack.Implementations.Requests.Banks
{
    public class BankAccountNameQueryRequest : IBankAccountNameQueryRequest
    {
        public BankAccountNameQueryRequest (string accountNumber, string bankReference)
        {
            AccountNumber = accountNumber;
            BankReference = bankReference;
        }

        public string AccountNumber { get; }

        public string BankReference { get; }

        public Task<string> Serialize () => Task.FromResult($"?account_number={AccountNumber}&bank_code={BankReference}");
    }
}
