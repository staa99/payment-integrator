using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;
using Staaworks.PaymentIntegrator.Paystack.Utilities;
using Staaworks.PaymentIntegrator.Utilities;
using static StaaPaymentIntegrator.Paystack.Tests.TestUtilities.TestConstants;

namespace StaaPaymentIntegrator.Paystack.Tests.TestUtilities
{
    public class TestPaystackCaller<TResponse> : PaystackCaller where TResponse : class, IResponse, new()
    {
        public override async Task<IResponse> Call ()
        {
            if (SecretKey == PaystackValidSecretKey)
            {
                return await GetSuccessResponse();
            }
            else
            {
                return await GetErrorResponse();
            }
        }


        private async Task<TResponse> GetSuccessResponse ()
        {
            var jsonResponse = "";

            var endpoint = Url.Split('?')[0];
            switch (endpoint)
            {
                case PaystackGetBanksUrl:
                    jsonResponse = PaystackGetBanksSuccessResponse;
                    break;

                case PaystackResolveAccountNameUrl:
                    jsonResponse = PaystackResolveAccountNameSuccessResponse;
                    break;

                case PaystackInitializePaymentUrl:
                    jsonResponse = PaystackInitializePaymentSuccessResponse;
                    break;
            }

            return await SimpleResponseInitializer.Initialize<TResponse>(jsonResponse);
        }


        private async Task<TResponse> GetErrorResponse ()
        {
            var jsonResponse = @"{
                                    ""status"": false,
                                    ""message"": ""An error occurred while performing the request""
                                 }";
            return await SimpleResponseInitializer.Initialize<TResponse>(jsonResponse);
        }


        private string PaystackGetBanksSuccessResponse => @"{
                                                    ""status"": true,
                                                    ""message"": ""Banks retrieved"",
                                                    ""data"": [
                                                        {
                                                            ""name"": ""Access Bank"",
                                                            ""slug"": ""access-bank"",
                                                            ""code"": ""044"",
                                                            ""longcode"": ""044150149"",
                                                            ""gateway"": ""etz"",
                                                            ""active"": true,
                                                            ""is_deleted"": null,
                                                            ""id"": 1,
                                                            ""createdAt"": ""2016-07-14T10:04:29.000Z"",
                                                            ""updatedAt"": ""2016-07-14T10:04:29.000Z""
                                                        },
                                                        {
                                                            ""name"": ""Citibank Nigeria"",
                                                            ""slug"": ""citibank-nigeria"",
                                                            ""code"": ""023"",
                                                            ""longcode"": ""023150005"",
                                                            ""gateway"": """",
                                                            ""active"": true,
                                                            ""is_deleted"": null,
                                                            ""id"": 2,
                                                            ""createdAt"": ""2016-07-14T10:04:29.000Z"",
                                                            ""updatedAt"": ""2016-07-14T10:04:29.000Z""
                                                        }
                                                    ]
                                                }";


        private string PaystackResolveAccountNameSuccessResponse => @"{
                                                                ""status"": true,
                                                                ""message"": ""Account number resolved"",
                                                                ""data"": {
                                                                ""account_number"": ""0241904090"",
                                                                ""account_name"": ""staa""
                                                                }
                                                             }";


        private string PaystackInitializePaymentSuccessResponse => @"{
                                                                        ""status"": true,
                                                                        ""message"": ""Authorization URL created"",
                                                                        ""data"": {
                                                                            ""authorization_url"": ""https://checkout.paystack.com/0peioxfhpn"",
                                                                            ""access_code"": ""0peioxfhpn"",
                                                                            ""reference"": ""7PVGX8MEk85tgeEpVDtD""
                                                                        }
                                                                    }";
    }
}