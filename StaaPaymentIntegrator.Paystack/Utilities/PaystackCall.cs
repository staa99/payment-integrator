using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Utilities;
using System.Threading;

namespace Staaworks.PaymentIntegrator.Paystack.Utilities
{
    public class PaystackCaller : APICaller, IPaystackCall
    {
        public string SecretKey { get; private set; }

        public async override Task<IResponse> Call ()
        {
            if (!OutputResponse(out var response, out var ex))
            {
                return await OnError(ex);
            }

            try
            {
                if (response != null)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var json = streamReader.ReadToEnd();
                        return await OnResult(json, ((HttpWebResponse) response).StatusCode);
                    }
                }
            }
            catch { }

            // if we get here, something failed
            var e = new Exception("The payment provider failed to respond.");
            return await OnError(e);
        }


        public override APICaller Initialize (
                                string method,
                                string url,
                                string secretKey,
                                Func<Exception, Task<IResponse>> onError,
                                Func<string, HttpStatusCode, Task<IResponse>> onResult,
                                string rawData = null
                            )
        {
            Method = method;
            Url = url;
            SecretKey = secretKey;
            OnError = onError;
            OnResult = onResult;

            RawData = rawData;

            return this;
        }
        

        protected virtual WebRequest GetRequest ()
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = Method;
            request.ContentType = "application/json";
            request.Headers[HttpRequestHeader.Authorization] = "Bearer " + SecretKey;

            if (RawData != null)
            {
                request.BeginGetRequestStream(ar =>
                {
                    using (var streamWriter = new StreamWriter(request.EndGetRequestStream(ar)))
                    {
                        streamWriter.Write(RawData);
                        streamWriter.Flush();
                    }
                }, request);
            }
            return request;
        }

        /*private void PerformSSLHack ()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // allows for validation of SSL conversations
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }*/

        private bool OutputResponse (out WebResponse response, out Exception ex)
        {
            var request = GetRequest();
            //PerformSSLHack();
            var evt = new ManualResetEvent (false);


            WebResponse r = null;
            Exception exception = null;
            bool result = false;

            request.BeginGetResponse(ar =>
            {
                try
                {
                    r = request.EndGetResponse(ar);
                    exception = null;
                    result = true;
                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        r = e.Response;
                        exception = null;
                        result = true;
                    }
                    else
                    {
                        r = null;
                        exception = e;
                        result = false;
                    }
                }
                evt.Set();
            }, null);
            evt.WaitOne();

            response = r;
            ex = exception;

            return result;
        }
    }
}
