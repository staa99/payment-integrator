using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace Staaworks.PaymentIntegrator.Providers
{
    public abstract class BaseBanksListProvider : IBanksProvider
    {
        public string Name { get; protected set; }

        public string BanksListUrl { get; protected set; }
        public string BankAccountNameQueryUrl { get; protected set; }
        public string SecretKey { get; protected set; }

        public abstract Task<IBanksResponse> GetBanks ();
        public abstract Task<IBankAccountNameQueryResponse> QueryAccountName (IBankAccountNameQueryRequest request);
    }
}
