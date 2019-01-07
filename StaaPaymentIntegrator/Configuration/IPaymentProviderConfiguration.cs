namespace Staaworks.PaymentIntegrator.Configuration
{
    public interface IPaymentProviderConfiguration
    {
        string ProviderName { get; }

        string SecretKey { get; }
    }
}