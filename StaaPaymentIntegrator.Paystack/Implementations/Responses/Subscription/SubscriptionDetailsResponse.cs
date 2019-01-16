using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Subscription
{
    public class SubscriptionDetailsResponse : BaseResponse, ISubscriptionDetailsResponse
    {
        public int Quantity { get; private set; }

        public long Amount { get; private set; }

        public string Reference { get; private set; }

        public string PlanReference { get; private set; }

        public string EmailToken { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            if (data != null && status == nameof(APICallStatus.success))
            {
                Quantity = data["quantity"].ToObject<int>();
                Amount = data["amount"].ToObject<long>();
                EmailToken = data["email_token"].ToString();
                Reference = data["subscription_code"].ToString();
                PlanReference = data["plan"]["plan_code"].ToString();
            }
        });
    }
}
