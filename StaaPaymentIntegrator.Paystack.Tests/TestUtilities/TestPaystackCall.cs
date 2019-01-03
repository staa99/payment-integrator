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

                case PaystackRequestReauthorizationUrl:
                    jsonResponse = PaystackRequestReauthorizationSuccessResponse;
                    break;

                case PaystackChargeAuthorizationSuccessUrl:
                    jsonResponse = PaystackChargeAuthorizationSuccessResponse;
                    break;

                case PaystackChargeAuthorizationFailedUrl:
                    jsonResponse = PaystackChargeAuthorizationFailedResponse;
                    break;

                case PaystackCheckAuthorizationUrl:
                    jsonResponse = PaystackCheckAuthorizationSuccessResponse;
                    break;

                default:
                    if (endpoint.StartsWith(PaystackVerifyPaymentSuccessUrl))
                    {
                        jsonResponse = PaystackVerificationSuccessResponse;
                    }
                    else if (endpoint.StartsWith(PaystackVerifyPaymentFailedUrl))
                    {
                        jsonResponse = PaystackVerificationFailedResponse;
                    }
                    else
                    {
                        jsonResponse = PaystackBadRequestErrorResponse;
                    }
                    break;
            }



            return await SimpleResponseInitializer.Initialize<TResponse>(jsonResponse);
        }


        private async Task<TResponse> GetErrorResponse ()
        {
            var jsonResponse = PaystackBadRequestErrorResponse; 
            return await SimpleResponseInitializer.Initialize<TResponse>(jsonResponse);
        }


        private string PaystackBadRequestErrorResponse =>   @"{
                                                                ""status"": false,
                                                                ""message"": ""An error occurred while performing the request""
                                                            }";


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

        private string PaystackVerificationSuccessResponse => @"{  
                                                                    ""status"":true,
                                                                    ""message"":""Verification successful"",
                                                                    ""data"":
                                                                    {
                                                                        ""amount"":27000,
                                                                        ""currency"":""NGN"",
                                                                        ""transaction_date"":""2016-10-01T11:03:09.000Z"",
                                                                        ""status"":""success"",
                                                                        ""reference"":""DG4uishudoq90LD"",
                                                                        ""domain"":""test"",
                                                                        ""metadata"":0,
                                                                        ""gateway_response"":""Successful"",
                                                                        ""message"":null,
                                                                        ""channel"":""card"",
                                                                        ""ip_address"":""41.1.25.1"",
                                                                        ""log"":
                                                                        {
                                                                            ""time_spent"":9,
                                                                            ""attempts"":1,
                                                                            ""authentication"":null,
                                                                            ""errors"":0,
                                                                            ""success"":true,
                                                                            ""mobile"":false,
                                                                            ""input"":[ ],
                                                                            ""channel"":null,
                                                                            ""history"":[  
                                                                                {  
                                                                                    ""type"":""input"",
                                                                                    ""message"":""Filled these fields: card number, card expiry, card cvv"",
                                                                                    ""time"":7
                                                                                },
                                                                                {  
                                                                                    ""type"":""action"",
                                                                                    ""message"":""Attempted to pay"",
                                                                                    ""time"":7
                                                                                },
                                                                                {  
                                                                                    ""type"":""success"",
                                                                                    ""message"":""Successfully paid"",
                                                                                    ""time"":8
                                                                                },
                                                                                {  
                                                                                    ""type"":""close"",
                                                                                    ""message"":""Page closed"",
                                                                                    ""time"":9
                                                                                }
                                                                            ]
                                                                        },
                                                                        ""fees"":null,
                                                                        ""authorization"":
                                                                        {  
                                                                            ""authorization_code"":""AUTH_8dfhjjdt"",
                                                                            ""card_type"":""visa"",
                                                                            ""last4"":""1381"",
                                                                            ""exp_month"":""08"",
                                                                            ""exp_year"":""2018"",
                                                                            ""bin"":""412345"",
                                                                            ""bank"":""TEST BANK"",
                                                                            ""channel"":""card"",
                                                                            ""signature"": ""SIG_idyuhgd87dUYSHO92D"",
                                                                            ""reusable"":true,
                                                                            ""country_code"":""NG""
                                                                        },
                                                                        ""customer"":
                                                                        {  
                                                                            ""id"":84312,
                                                                            ""customer_code"":""CUS_hdhye17yj8qd2tx"",
                                                                            ""first_name"":""BoJack"",
                                                                            ""last_name"":""Horseman"",
                                                                            ""email"":""bojack@horseman.com""
                                                                        },
                                                                        ""plan"":""PLN_0as2m9n02cl0kp6""
                                                                    }
                                                                }";

        private string PaystackVerificationFailedResponse => @"{  
                                                                   ""status"":true,
                                                                   ""message"":""Verification successful"",
                                                                   ""data"":{  
                                                                      ""amount"":27000,
                                                                      ""currency"":""NGN"",
                                                                      ""transaction_date"":""2016-10-01T11:03:09.000Z"",
                                                                      ""status"":""failed"",
                                                                      ""reference"":""djfoidjkdkj41"",
                                                                      ""domain"":""test"",
                                                                      ""metadata"":0,
                                                                      ""gateway_response"":""Insufficient Funds"",
                                                                      ""message"":null,
                                                                      ""channel"":""card"",
                                                                      ""ip_address"":""41.1.25.1"",
                                                                      ""log"":{  
                                                                         ""time_spent"":9,
                                                                         ""attempts"":1,
                                                                         ""authentication"":null,
                                                                         ""errors"":0,
                                                                         ""success"":true,
                                                                         ""mobile"":false,
                                                                         ""input"":[ ],
                                                                         ""channel"":null,
                                                                         ""history"":[  
                                                                            {  
                                                                               ""type"":""input"",
                                                                               ""message"":""Filled these fields: card number, card expiry, card cvv"",
                                                                               ""time"":7
                                                                            },
                                                                            {  
                                                                               ""type"":""action"",
                                                                               ""message"":""Attempted to pay"",
                                                                               ""time"":7
                                                                            },
                                                                            {  
                                                                               ""type"":""close"",
                                                                               ""message"":""Page closed"",
                                                                               ""time"":9
                                                                            }
                                                                         ]
                                                                      },
                                                                      ""fees"":null,
                                                                      ""authorization"":{  
                                                                         ""authorization_code"":""AUTH_8dfhjjdt"",
                                                                         ""card_type"":""visa"",
                                                                         ""last4"":""1381"",
                                                                         ""exp_month"":""08"",
                                                                         ""exp_year"":""2018"",
                                                                         ""bin"":""412345"",
                                                                         ""bank"":""TEST BANK"",
                                                                         ""channel"":""card"",
                                                                         ""signature"": ""SIG_idyuhgd87dUYSHO92D"",
                                                                         ""reusable"":true,
                                                                         ""country_code"":""NG""
                                                                      },
                                                                      ""customer"":{  
                                                                         ""id"":84312,
                                                                         ""customer_code"":""CUS_hdhye17yj8qd2tx"",
                                                                         ""first_name"":""BoJack"",
                                                                         ""last_name"":""Horseman"",
                                                                         ""email"":""bojack@horseman.com""
                                                                      },
                                                                      ""plan"":""""
                                                                   }
                                                                }";

        private string PaystackRequestReauthorizationSuccessResponse => @" {
                                                                        ""status"": true,
                                                                        ""message"": ""Reauthorization initiated"",
                                                                        ""data"":
                                                                        {
                                                                            ""reauthorization_url"": ""https://paystack.com/authorize/10001"",
                                                                            ""reference"": ""1nv4LiD""
                                                                        }
                                                                    }";

        private string PaystackCheckAuthorizationSuccessResponse => @" {
                                                                    ""status"": true,
                                                                    ""message"": ""Authorization is valid for this amount"",
                                                                    ""data"":
                                                                    {
                                                                        ""amount"": ""400"",
                                                                        ""currency"": ""NGN""
                                                                    }
                                                                }";

        private string PaystackChargeAuthorizationSuccessResponse => @" {
                                                                    ""status"": true,
                                                                    ""message"": ""Charge attempted"",
                                                                    ""data"": {
                                                                        ""amount"": 500000,
                                                                        ""currency"": ""NGN"",
                                                                        ""transaction_date"": ""2016-10-01T14:29:53.000Z"",
                                                                        ""status"": ""success"",
                                                                        ""reference"": ""0bxco8lyc2aa0fq"",
                                                                        ""domain"": ""live"",
                                                                        ""metadata"": null,
                                                                        ""gateway_response"": ""Successful"",
                                                                        ""message"": null,
                                                                        ""channel"": ""card"",
                                                                        ""ip_address"": null,
                                                                        ""log"": null,
                                                                        ""fees"": null,
                                                                        ""authorization"": {
                                                                            ""authorization_code"": ""AUTH_5z72ux0koz"",
                                                                            ""bin"": ""408408"",
                                                                            ""last4"": ""4081"",
                                                                            ""exp_month"": ""12"",
                                                                            ""exp_year"": ""2020"",
                                                                            ""channel"": ""card"",
                                                                            ""card_type"": ""visa DEBIT"",
                                                                            ""bank"": ""Test Bank"",
                                                                            ""country_code"": ""NG"",
                                                                            ""brand"": ""visa"",
                                                                            ""reusable"": true,
                                                                            ""signature"": ""SIG_ZdUx7Z5ujd75rt9OMTN4""
                                                                        },
                                                                        ""customer"": {
                                                                            ""id"": 90831,
                                                                            ""customer_code"": ""CUS_fxg9930u8pqeiu"",
                                                                            ""first_name"": ""Bojack"",
                                                                            ""last_name"": ""Horseman"",
                                                                            ""email"": ""bojack@horsinaround.com""
                                                                        },
                                                                        ""plan"": 0
                                                                    }
                                                                }";

        private string PaystackChargeAuthorizationFailedResponse => @"  {  
                                                                    ""status"":true,
                                                                    ""message"":""Charge Attempted"",
                                                                    ""data"":
                                                                    {  
                                                                        ""amount"":27000,
                                                                        ""currency"":""NGN"",
                                                                        ""transaction_date"":""2016-10-01T11:03:09.000Z"",
                                                                        ""status"":""failed"",
                                                                        ""reference"":""DG4uishudoq90LD"",
                                                                        ""domain"":""test"",
                                                                        ""metadata"":0,
                                                                        ""gateway_response"":""Insufficient Funds"",
                                                                        ""message"":null,
                                                                        ""channel"":""card"",
                                                                        ""ip_address"":""41.1.25.1"",
                                                                        ""log"":null,
                                                                        ""fees"":null,
                                                                        ""authorization"":
                                                                        {  
                                                                            ""authorization_code"": ""AUTH_5z72ux0koz"",
                                                                            ""bin"": ""408408"",
                                                                            ""last4"": ""4081"",
                                                                            ""exp_month"": ""12"",
                                                                            ""exp_year"": ""2020"",
                                                                            ""channel"": ""card"",
                                                                            ""card_type"": ""visa DEBIT"",
                                                                            ""bank"": ""Test Bank"",
                                                                            ""country_code"": ""NG"",
                                                                            ""brand"": ""visa"",
                                                                            ""reusable"": true,
                                                                            ""signature"": ""SIG_ZdUx7Z5ujd75rt9OMTN4""
                                                                        },
                                                                        ""customer"":
                                                                        {  
                                                                            ""id"":84312,
                                                                            ""customer_code"":""CUS_hdhye17yj8qd2tx"",
                                                                            ""first_name"":""BoJack"",
                                                                            ""last_name"":""Horseman"",
                                                                            ""email"":""bojack@horseman.com""
                                                                        },
                                                                        ""plan"":""PLN_0as2m9n02cl0kp6""
                                                                    }
                                                                }";
    }
}