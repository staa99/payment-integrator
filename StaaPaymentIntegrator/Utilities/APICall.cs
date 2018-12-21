using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;

namespace Staaworks.PaymentIntegrator.Utilities
{
    public abstract class APICall<IResponseType> where IResponseType : IResponse
    {
        public string Url { get; protected set; }
        public string Method { get; protected set; }
        public string RawData { get; protected set; }

        public Func<Exception, Task<IResponseType>> OnError { get; protected set; }
        public Func<string, HttpStatusCode, Task<IResponseType>> OnResult { get; protected set; }

        public abstract Task<IResponseType> Call ();
    }
}
