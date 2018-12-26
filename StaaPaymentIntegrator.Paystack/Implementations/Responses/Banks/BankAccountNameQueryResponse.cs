using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Banks
{
    public class BankAccountNameQueryResponse : BaseResponse, IBankAccountNameQueryResponse
    {
        public string AccountName { get; private set; }

        public string AccountNumber { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                AccountName = data["account_name"].ToString();
                AccountNumber = data["account_number"].ToString();
            }
        });
    }
}
