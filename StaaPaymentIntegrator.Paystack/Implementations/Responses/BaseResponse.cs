using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses
{
    public abstract class BaseResponse : IResponse
    {
        public string Status { get; protected set; }

        public string Raw { get; private set; }

        public Task Parse (string response)
        {
            try
            {
                var token = JObject.Parse(response);

                string status;
                var data = token["data"];
                if (data == null || data["status"] == null)
                {
                    status = token["status"].ToString();
                }
                else
                {
                    status = data["status"].ToString();
                }


                if (bool.TryParse(status, out var boolStatus))
                {
                    if (boolStatus)
                    {
                        Status = nameof(APICallStatus.success);
                    }
                    else
                    {
                        Status = nameof(APICallStatus.failed);
                    }
                }
                else
                {
                    Status = status;
                }

                Raw = response;

                var ret = DoParse(data, Status);
                return ret;
            }
            catch (JsonException ex)
            {
                throw new FormatException("The response from the API is not well formed", ex);
            }
        }

        protected abstract Task DoParse (JToken data, string status);
    }
}
