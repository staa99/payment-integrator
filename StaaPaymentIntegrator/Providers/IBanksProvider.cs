using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace Staaworks.PaymentIntegrator.Providers
{
    public interface IBanksProvider : IProvider
    {
        string BanksListUrl { get; }
        string BankAccountNameQueryUrl { get; }

        Task<IBanksResponse> GetBanks ();
        Task<IBankAccountNameQueryResponse> QueryAccountName (IBankAccountNameQueryRequest request);
    }
}
