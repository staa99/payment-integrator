using Staaworks.PaymentIntegrator.Utilities;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface IProvider
    {
        string Name { get; }

        string SecretKey { get; }

        APICaller Caller { get; }
    }
}