using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.BankTransfer
{
    public class BankTransferRecipientCreationResponse : BaseResponse, IBankTransferRecipientCreationResponse
    {
        public string RecipientReference { get; private set; }

        public string AccountName { get; private set; }

        public string BankName { get; private set; }

        public string BankReference { get; private set; }

        public string RecipientName { get; private set; }

        public string AccountNumber { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                RecipientReference = data["recipient_code"].ToString();
                RecipientName = data["name"].ToString();

                var details = data["details"];
                AccountName = details["account_name"].ToString();
                AccountNumber = details["account_number"].ToString();
                BankReference = details["bank_code"].ToString();
                BankName = details["bank_name"].ToString();
            }
        });
    }
}
