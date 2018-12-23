using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentVerificationResponse : BaseResponse, IPaymentVerificationResponse
    {
        internal PaymentVerificationResponse () { }

        public bool Successful { get; private set; }

        public string AuthorizationReference { get; private set; }

        public string Reference { get; private set; }

        public string Message { get; private set; }

        public long Amount { get; private set; }

        public string Currency { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null)
            {
                Successful = status == nameof(APICallStatus.success);

                Amount = data["amount"].ToObject<long>();
                Currency = data["currency"].ToString();
                Message = data["gateway_response"].ToString();
                Reference = data["reference"].ToString();

                if (Successful)
                {
                    var authorization = data["authorization"];
                    if (authorization["reusable"].ToObject<bool>())
                    {
                        AuthorizationReference = authorization["authorization_code"].ToString();
                    }
                }
            }
        });
    }
}