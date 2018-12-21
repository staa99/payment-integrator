using System;
using System.Collections.Generic;
using System.Text;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Banks
{
    public interface IBankAccountNameQueryRequest
    {
        string AccountNumber { get; }
        string BankReference { get; }
    }
}
