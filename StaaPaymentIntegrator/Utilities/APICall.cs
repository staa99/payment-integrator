using System;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;

namespace Staaworks.PaymentIntegrator.Utilities
{
    public abstract class APICall<IResponseType> where IResponseType : IResponse
    {
        public string Url { get; }
        public string Method { get; }
        public string RawData { get; }

        public Action OnError { get; }

        public abstract Task<IResponseType> Call ();
    }
}
