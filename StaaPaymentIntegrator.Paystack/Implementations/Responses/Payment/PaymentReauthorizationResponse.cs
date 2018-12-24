using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentReauthorizationResponse : BaseResponse, IPaymentReauthorizationResponse
    {
        internal PaymentReauthorizationResponse () { }


        public string Reference { get; private set; }

        public string Message { get; private set; }

        public string ReauthorizationUrl { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Reference = data["reference"].ToString();
                Message = data.Parent["message"].ToString();
                ReauthorizationUrl = data["reauthorization_url"].ToString();
            }
        });
    }
}
