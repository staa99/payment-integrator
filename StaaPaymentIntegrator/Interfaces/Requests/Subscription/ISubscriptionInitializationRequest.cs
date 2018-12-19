using System;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests.SubscriptionInitialization
{
    public interface ISubscriptionInitializationRequest
    {
        string Customer { get; }

        string PlanReference { get; }

        DateTime StartDate { get; }
    }
}
