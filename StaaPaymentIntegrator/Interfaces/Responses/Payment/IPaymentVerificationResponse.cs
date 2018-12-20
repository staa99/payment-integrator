using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentVerificationResponse : ITransactionResponse
    {
        bool Successful { get; }

        string PaymentRef { get; }

        string BookingRef { get; }

        string Message { get; }

        string Status { get; }

        long AmountPaid { get; }
        Task ParseJson (string json);
    }
}
