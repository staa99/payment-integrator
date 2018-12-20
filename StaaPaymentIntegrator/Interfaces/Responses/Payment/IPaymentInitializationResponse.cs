namespace Staaworks.PaymentIntegrator.Interfaces.Responses.PaymentInitialization
{
    public interface IPaymentInitializationResponse : ITransactionResponse
    {
        long AmountInvoiced { get; }

        string Reference { get; }

        string Message { get; }

        string AuthorizationUrl { get; }
    }
}