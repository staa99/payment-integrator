using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses;

namespace StaaPaymentIntegrator.Paystack.Implementations.Responses
{
    public abstract class BaseResponse : IResponse
    {
        public string Status { get; protected set; }

        public string Raw { get; private set; }

        public Task Parse (string response)
        {
            try
            {
                var ret = DoParse(JObject.Parse(response));
                Raw = response;
                return ret;
            }
            catch (JsonException ex)
            {
                throw new FormatException("The response from the API is not well formed", ex);
            }
        }

        protected abstract Task DoParse (JObject token);
    }
}
