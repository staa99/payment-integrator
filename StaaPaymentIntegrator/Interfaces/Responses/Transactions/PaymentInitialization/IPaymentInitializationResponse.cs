using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentInitialization
{
    public  interface IPaymentInitializationResponse : ITransactionResponse
    {
        double AmountInvoiced { get; set; }

        string Reference { get; set; }

        string Status { get; set; }

        string Message { get; set; }
        
        string AuthorizationUrl { get; set; }

        string RawPaymentInitJSONResult { get; set; }

        Task ParseJson (string json);
    }
}
