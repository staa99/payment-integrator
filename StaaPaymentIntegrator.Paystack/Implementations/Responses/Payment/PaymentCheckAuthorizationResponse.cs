using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentCheckAuthorizationResponse : BaseResponse, IPaymentCheckAuthorizationResponse
    {
        public long Amount { get; private set; }

        public string Currency { get; private set; }


        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Amount = data["amount"].ToObject<long>();
                Message = data.Root["message"].ToString();
                Currency = data["currency"].ToString();
            }
        });
    }
}
