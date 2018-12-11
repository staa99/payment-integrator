using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Providers
{
    /// <summary>
    /// This class is intended for use with DI containers. The particular implementation will be responsible for building its own payment provider.
    /// </summary>
    public interface IPaymentProviderBuilder
    {
        Task<IPaymentProvider> Build ();
    }
}
