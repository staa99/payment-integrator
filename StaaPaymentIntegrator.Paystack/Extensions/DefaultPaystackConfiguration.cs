namespace Staaworks.PaymentIntegrator.Paystack.Extensions
{
    public class DefaultPaystackConfiguration : IPaystackConfiguration
    {
        private const string apiBaseUrl = "https://api.paystack.co";


        public DefaultPaystackConfiguration (string secretKey, string providerName = "PAYSTACK")
        {
            SecretKey = secretKey;
            ProviderName = providerName;
        }

        public string ProviderName { get; private set; }

        public string SecretKey { get; private set; }


        public string BanksListUrl => apiBaseUrl + "/bank";

        public string BankAccountNameQueryUrl => apiBaseUrl + "/bank/resolve";

        public string PaymentVerificationUrl => apiBaseUrl + "/transaction/verify";

        public string PaymentInitializationUrl => apiBaseUrl + "/transaction/initialize";

        public string PaymentChargeAuthorizationUrl => apiBaseUrl + "/transaction/charge_authorization";

        public string PaymentReauthorizationUrl => apiBaseUrl + "/transaction/request_reauthorization";

        public string PaymentCheckAuthorizationUrl => apiBaseUrl + "/transaction/check_authorization";

        public string SubscriptionInitializationUrl => apiBaseUrl + "/subscription";

        public string SubscriptionActivationUrl => apiBaseUrl + "/subscription/enable";

        public string SubscriptionDeactivationUrl => apiBaseUrl + "/subscription/disable";

        public string SubscriptionPlanCreationUrl => apiBaseUrl + "/plan";

        public string SubscriptionPlanQueryUrl => apiBaseUrl + "/plan";

        public string SubscriptionQueryUrl => apiBaseUrl + "/subscription";

        public string BankTransferRecipientCreationUrl => apiBaseUrl + "/transferrecipient";

        public string BankTransferInitiationUrl => apiBaseUrl + "/transfer";
    }
}