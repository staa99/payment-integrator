using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses
{
    public interface IResponse
    {
        string Status { get; }
        string Raw { get; }
        Task Parse (string response);
    }
}
