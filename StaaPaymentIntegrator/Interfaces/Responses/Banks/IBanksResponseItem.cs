namespace Staaworks.PaymentIntegrator.Interfaces.Responses.Banks
{
    public interface IBanksResponseItem
    {
        string Name { get; }
        string Reference { get; }
        string Raw { get; }
    }
}