using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentInitializationResponse : BaseResponse, IPaymentInitializationResponse
    {
        public string Reference { get; private set; }

        public string Message { get; private set; }

        public string AuthorizationUrl { get; private set; }

        protected override Task DoParse (JObject token, string status) => Task.Run(() =>
        {
            var data = token["data"];
            
            if (data != null && status == nameof(APICallStatus.success))
            {
                Reference = data["reference"].ToString();
                Message = token["message"].ToString();
                AuthorizationUrl = data["authorization_url"].ToString();
            }
        });
    }
}