using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests.SubscriptionInitialization
{
    public interface ISubscriptionPlanCreationRequest
    {
        string Name { get; }
        long CycleDurationInHours { get; }
        long Amount { get; }
        string Currency { get; }
        JObject SerializeToJson ();
    }
}
