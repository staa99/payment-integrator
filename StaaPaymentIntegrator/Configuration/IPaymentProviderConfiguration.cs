namespace Staaworks.PaymentIntegrator.Configuration
{
    internal interface IPaymentProviderConfiguration
    {
        string Name { get; }

        string BanksListUrl { get; }

        string SecretKey { get; }

        string CallbackUrl { get; }
    }
}