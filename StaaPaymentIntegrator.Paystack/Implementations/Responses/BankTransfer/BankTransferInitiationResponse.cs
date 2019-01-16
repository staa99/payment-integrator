using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.BankTransfer;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.BankTransfer
{
    public class BankTransferInitiationResponse : BaseResponse, IBankTransferInitiationResponse
    {
        public string TransferReference { get; private set; }

        public long Amount { get; private set; }

        public string Currency { get; private set; } = "NGN";

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Amount = data["amount"].ToObject<long>();
                Currency = data["currency"].ToString();
                TransferReference = data["transfer_code"].ToString();
            }
        });
    }
}