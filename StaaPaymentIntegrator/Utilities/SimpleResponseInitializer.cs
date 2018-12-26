using System.Threading.Tasks;
using Staaworks.PaymentIntegrator.Interfaces.Responses;

namespace Staaworks.PaymentIntegrator.Utilities
{
    public static class SimpleResponseInitializer
    {
        public static async Task<TResponse> Initialize<TResponse> (string json) where TResponse : class, IResponse, new()
        {
            var response = new TResponse();
            await response.Parse(json);
            return response;
        }
    }
}
