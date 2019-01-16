using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Subscription;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Subscription
{
    public class SubscriptionDisableResponse : BaseResponse, ISubscriptionDisableResponse
    {
        protected override Task DoParse (JToken data, string status) => Task.FromResult(0);
    }
}
