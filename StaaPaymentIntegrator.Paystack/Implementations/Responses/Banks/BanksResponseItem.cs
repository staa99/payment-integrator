using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;

namespace StaaPaymentIntegrator.Paystack.Implementations.Responses.Banks
{
    public class BanksResponseItem : IBanksResponseItem
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Longcode { get; set; }
        public string Gateway { get; set; }
        public bool Active { get; set; }
        public string Reference { get; set; }
        public string Raw { get; set; }
    }
}