using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Subscription
{
    public class SubscriptionInitializationResponse : BaseResponse, ISubscriptionInitializationResponse
    {
        public string Reference { get; private set; }

        public string PlanReference { get; private set; }

        public string EmailToken { get; private set; }

        public long Amount { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            Reference = data["subscription_code"].ToString();
            PlanReference = data["plan"].ToString();
            Amount = data["amount"].ToObject<long>();
            EmailToken = data["email_token"].ToString();
        });
    }
}
