namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Payment
{
    public interface IPaymentReauthorizationResponse:IResponse
    {
        string Reference { get; }

        string Message { get; }

        string ReauthorizationUrl { get; }
    }
}
