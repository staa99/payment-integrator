using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations
{
    public abstract class BaseRequest : IRequest
    {
        public void Initialize (IDictionary<string, string> options)
        {
            try
            {
                InitializeWithOptions(options);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Cannot initialize request with the given options", ex);
            }
        }

        protected abstract void InitializeWithOptions (IDictionary<string, string> options);
        public abstract Task<string> Serialize ();
        public abstract bool Validate (out Exception ex);
    }
}
