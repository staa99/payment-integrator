using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace Staaworks.PaymentIntegrator.Providers
{
    interface IBanksListProvider
    {
        string Name { get; }

        string BanksListUrl { get; }

        Task<IBanksResponse> GetBanks ();
    }
}
