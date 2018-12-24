using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Payment;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment
{
    public class PaymentReauthorizationResponse : IPaymentReauthorizationResponse
    {
        public string Reference => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public string ReauthorizationUrl => throw new NotImplementedException();

        public string Status => throw new NotImplementedException();

        public string Raw => throw new NotImplementedException();

        public Task Parse (string response) => throw new NotImplementedException();
    }
}
