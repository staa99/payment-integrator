using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentVerification
{
    public interface IPaymentVerificationResponse : ITransactionResponse
    {
        bool Successful { get; }

        string PaymentRef { get; }

        string BookingRef { get; }

        string Message { get; }

        string Status { get; }

        double AmountPaid { get; }

        string RawJson { get; }

        Task ParseJson (string json);
    }
}
