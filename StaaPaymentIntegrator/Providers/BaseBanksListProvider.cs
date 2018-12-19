using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace Staaworks.PaymentIntegrator.Providers
{
    public abstract class BaseBanksListProvider : IBanksListProvider
    {
        public string Name { get; protected set; }

        public string BanksListUrl { get; protected set; }

        public abstract Task<IBanksResponse> GetBanks ();
    }
}
