namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBanksResponseItem
    {
        string Name { get; }
        string Code { get; }
        string Raw { get; }
    }
}
