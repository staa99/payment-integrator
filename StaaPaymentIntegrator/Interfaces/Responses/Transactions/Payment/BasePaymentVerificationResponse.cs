using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.Payment
{
    public abstract class BasePaymentVerificationResponse : IPaymentVerificationResponse
    {
        public abstract bool Successful { get; }
        public abstract string PaymentRef { get; }
        public abstract string BookingRef { get; }
        public abstract string Message { get; }
        public abstract string Status { get; }
        public abstract long AmountPaid { get; }
        public abstract string TransactionRef { get; }
        public abstract string TransactionContent { get; }

        public abstract Task ParseJson (string json);
    }
}