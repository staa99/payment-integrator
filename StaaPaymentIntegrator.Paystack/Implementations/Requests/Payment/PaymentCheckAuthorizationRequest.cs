using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Payment;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment
{
    public class PaymentCheckAuthorizationRequest : IPaymentCheckAuthorizationRequest
    {
        public string AuthorizationReference => throw new NotImplementedException();

        public string Amount => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public string Currency => throw new NotImplementedException();

        public Task<string> Serialize () => throw new NotImplementedException();
        public bool Validate (out Exception ex) => throw new NotImplementedException();
    }
}
