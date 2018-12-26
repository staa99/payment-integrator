using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;

namespace Staaworks.PaymentIntegrator.Utilities
{
    public abstract class APICaller
    {
        public string Url { get; protected set; }
        public string Method { get; protected set; }
        public string RawData { get; protected set; }

        public Func<Exception, Task<IResponse>> OnError { get; protected set; }
        public Func<string, HttpStatusCode, Task<IResponse>> OnResult { get; protected set; }

        public abstract Task<IResponse> Call ();
        public abstract APICaller Initialize (
                                string method,
                                string url,
                                string secretKey,
                                Func<Exception, Task<IResponse>> onError,
                                Func<string, HttpStatusCode, Task<IResponse>> onResult,
                                string rawData = null
                            );
    }
}
