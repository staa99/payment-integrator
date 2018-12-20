using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace Staaworks.PaymentIntegrator.Providers
{
    interface IBanksListProvider : IProvider
    {
        string BanksListUrl { get; }

        Task<IBanksResponse> GetBanks ();
    }
}
