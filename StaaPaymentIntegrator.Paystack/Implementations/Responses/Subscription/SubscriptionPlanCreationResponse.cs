using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;
using Staaworks.PaymentIntegrator.Paystack.Utilities;
using static Staaworks.PaymentIntegrator.Paystack.InitializationOptions;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Subscription
{
    public class SubscriptionPlanCreationResponse : BaseResponse, ISubscriptionPlanCreationResponse
    {
        public string Reference { get; private set; }

        public long CycleDurationInHours { get; private set; }

        public long Amount { get; private set; }

        public string Currency { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Amount = data["amount"].ToObject<long>();
                Currency = data["currency"].ToString();
                Reference = data["plan_code"].ToString();
                CycleDurationInHours = IntervalMap.ToDictionary(p => p.Value, p => p.Key)[data["interval"].ToString()];
            }
        });
    }
}
