namespace StaaPaymentIntegrator.Paystack.Tests.TestUtilities
{
    internal class TestConstants
    {
        public const string
            PaystackValidSecretKey = "sk_utests_hdjhjdsujisdyui389wejskjcxjkcx",
            PaystackGetBanksUrl = "https://test.com/getbanks",
            PaystackResolveAccountNameUrl = "https://test.com/resolveaccountname",
            PaystackInitializePaymentUrl = "https://test.com/initialize",
            PaystackVerifyPaymentUrl = "https://test.com/verify",
            PaystackChargeAuthorizationUrl = "https://test.com/authorization/charge",
            PaystackCheckAuthorizationUrl = "https://test.com/authorization/check",
            PaystackRequestReauthorizationUrl = "https://test.com/reauthorize";
    }
}
