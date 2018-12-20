using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization
{
    public  interface IPaymentInitializationResponse : ITransactionResponse
    {
        long AmountInvoiced { get; }

        string Reference { get; }

        string Status { get; }

        string Message { get; }
        
        string AuthorizationUrl { get; }

        Task ParseJson (string json);
    }
}
