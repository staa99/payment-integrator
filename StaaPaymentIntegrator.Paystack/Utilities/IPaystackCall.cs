using System;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Utilities
{
    public interface IPaystackCall
    {
        string SecretKey { get; }

        Task<IResponse> Call ();
        APICaller Initialize (string method, string url, string secretKey, Func<Exception, Task<IResponse>> onError, Func<string, HttpStatusCode, Task<IResponse>> onResult, string rawData = null);
    }
}