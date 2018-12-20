using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests
{
    public interface IRequest
    {
        Task<string> Serialize ();
    }
}
