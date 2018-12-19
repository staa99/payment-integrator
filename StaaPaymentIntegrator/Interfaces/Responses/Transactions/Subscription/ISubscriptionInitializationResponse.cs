using System;
using System.Collections.Generic;
using System.Text;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.Subscription
{
    public interface ISubscriptionInitializationResponse
    {
        string Reference { get; }
        string Status { get; }
        long Amount { get; }
    }
}
