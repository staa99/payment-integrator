using System;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Subscription
{
    public interface ISubscriptionInitializationRequest : IRequest
    {
        string CustomerReference { get; }

        string PlanReference { get; }

        DateTime StartDate { get; }
    }
}
