using System;

namespace Staaworks.PaymentIntegrator.Interfaces.Requests.Payment
{
    public interface IPaymentInitializationRequest : IRequest
    {
        string Email { get; }
        string Reference { get; }
        string Currency { get; }
        long Amount { get; }
        string CallbackUrl { get; }
    }
}
