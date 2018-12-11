using System.Threading.Tasks;

namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Transactions.PaymentVerification
{
    public abstract class BasePaymentVerificationResponse : IPaymentVerificationResponse
    {
        public abstract bool Successful { get; }
        public abstract string PaymentRef { get; }
        public abstract string BookingRef { get; }
        public abstract string Message { get; }
        public abstract string Status { get; }
        public abstract double AmountPaid { get; }
        public abstract string RawJson { get; }
        public abstract string TransactionRef { get; }
        public string TransactionContent => RawJson;

        public abstract Task ParseJson (string json);
    }
}
