using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Utilities;

namespace StaaPaymentIntegrator.Paystack.Utilities
{
    internal class PaystackCall<IResponseType> : APICall<IResponseType> where IResponseType : IResponse
    {
        public string SecretKey { get; private set; }
        public static Task<IResponseType> Get (
                                                    string url,
                                                    string secretKey,
                                                    Func<Exception, Task<IResponseType>> onError,
                                                    Func<string, HttpStatusCode, Task<IResponseType>> onResult
                                              ) =>
            CallImmediately("GET", url, secretKey, onError, onResult);

        public static Task<IResponseType> Post (
                                                    string url,
                                                    string secretKey,
                                                    string rawData,
                                                    Func<Exception, Task<IResponseType>> onError,
                                                    Func<string, HttpStatusCode, Task<IResponseType>> onResult
                                               ) =>
            CallImmediately("POST", url, secretKey, onError, onResult, rawData);


        public static async Task<IResponseType> CallImmediately (
                                                                    string method,
                                                                    string url,
                                                                    string secretKey,
                                                                    Func<Exception, Task<IResponseType>> onError,
                                                                    Func<string, HttpStatusCode, Task<IResponseType>> onResult,
                                                                    string rawData = null
                                                                )
        {
            var call = new PaystackCall<IResponseType>
            {
                Method = method,
                Url = url,
                SecretKey = secretKey,
                OnError = onError,
                OnResult = onResult
            };

            if (rawData != null)
            {
                call.RawData = rawData;
            }

            return await call.Call();
        }

        public async override Task<IResponseType> Call ()
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


        private HttpWebRequest GetRequest ()
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
