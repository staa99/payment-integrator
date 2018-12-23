using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentInitializationResponse : BaseResponse, IPaymentInitializationResponse
    {
        internal PaymentInitializationResponse () { }


        public string Reference { get; private set; }

        public string Message { get; private set; }

        public string AuthorizationUrl { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Reference = data["reference"].ToString();
                Message = data.Parent["message"].ToString();
                AuthorizationUrl = data["authorization_url"].ToString();
            }
        });
    }
}