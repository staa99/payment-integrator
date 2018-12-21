using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace StaaPaymentIntegrator.Paystack.Implementations.Responses.Banks
{
    public class BankAccountNameQueryResponse : BaseResponse, IBankAccountNameQueryResponse
    {
        public string AccountName { get; private set; }

        public string AccountNumber { get; private set; }

        protected override Task DoParse (JObject token) => Task.Run(() =>
        {
            var data = token["data"];
            var status = token["status"];

            if (data != null && status.ToObject<bool>())
            {
                AccountName = data["account_name"].ToString();
                AccountNumber = data["account_number"].ToString();
            }
        });
    }
}
