namespace StaaPaymentIntegrator.Paystack.Tests.TestUtilities
{
    internal class TestConstants
    {
        public const string
            PaystackValidSecretKey = "sk_utests_hdjhjdsujisdyui389wejskjcxjkcx",
            PaystackGetBanksUrl = "https://test.com/getbanks",
            PaystackResolveAccountNameUrl = "https://test.com/resolveaccountname",
            PaystackInitializePaymentUrl = "https://test.com/initialize",
            PaystackVerifyPaymentSuccessUrl = "https://test.com/verify/success",
            PaystackVerifyPaymentFailedUrl = "https://test.com/verify/failed",
            PaystackChargeAuthorizationSuccessUrl = "https://test.com/authorization/charge/success",
            PaystackChargeAuthorizationFailedUrl = "https://test.com/authorization/charge/failed",
            PaystackCheckAuthorizationUrl = "https://test.com/authorization/check",
            PaystackRequestReauthorizationUrl = "https://test.com/reauthorize";
    }
}
