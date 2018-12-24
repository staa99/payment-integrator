using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentCheckAuthorizationResponse : IPaymentCheckAuthorizationResponse
    {
        public long Amount => throw new NotImplementedException();

        public string Currency => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public string Status => throw new NotImplementedException();

        public string Raw => throw new NotImplementedException();

        public Task Parse (string response) => throw new NotImplementedException();
    }
}
