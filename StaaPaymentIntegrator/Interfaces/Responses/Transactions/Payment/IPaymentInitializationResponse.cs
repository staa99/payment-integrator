using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentInitialization
{
    public  interface IPaymentInitializationResponse : ITransactionResponse
    {
        long AmountInvoiced { get; set; }

        string Reference { get; set; }

        string Status { get; set; }

        string Message { get; set; }
        
        string AuthorizationUrl { get; set; }

        Task ParseJson (string json);
    }
}
