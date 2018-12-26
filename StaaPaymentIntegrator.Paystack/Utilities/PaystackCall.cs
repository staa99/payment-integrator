using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Utilities;

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

            if (rawData != null)
            {
                RawData = rawData;
            }

            return this;
        }
        

        protected virtual HttpWebRequest GetRequest ()
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = Method;
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + SecretKey);

            if (RawData != null)
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(RawData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            return request;
        }

        private void PerformSSLHack ()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // allows for validation of SSL conversations
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        private bool OutputResponse (out WebResponse response, out Exception ex)
        {
            try
            {
                var request = GetRequest();
                PerformSSLHack();
                response = request.GetResponse();
                ex = null;
                return true;
            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    response = e.Response;
                    ex = null;
                    return true;
                }
                else
                {
                    response = null;
                    ex = e;
                    return false;
                }
            }
        }
    }
}
