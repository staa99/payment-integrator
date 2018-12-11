using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBanksResponse
    {
        IDictionary<IBanksResponseItem, JObject> Banks { get; }
    }
}
