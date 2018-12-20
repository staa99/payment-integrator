namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBanksResponse : IResponse
    {
        IBanksResponseItem[] Banks { get; }
    }
}
