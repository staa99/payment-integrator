using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Banks
{
    /// <summary>
    /// This is the response to the GetBanks API. This provides a list of banks with needed data
    /// </summary>
    public class BanksResponse : BaseResponse, IBanksResponse
    {
        public IBanksResponseItem[] Banks { get; private set; }

        protected override Task DoParse (JToken data, string status) => Task.Run(() =>
        {
            var banks = new List<IBanksResponseItem>();
            if (data != null && status == nameof(APICallStatus.success))
            {
                foreach (var obj in data)
                {
                    var it = new BanksResponseItem
                    {
                        Reference = obj["code"].ToString(),
                        Active = obj["active"].ToObject<bool>(),
                        Gateway = obj["gateway"].ToString(),
                        Longcode = obj["longcode"].ToString(),
                        Name = obj["name"].ToString(),
                        Slug = obj["slug"].ToString(),
                        Raw = obj.ToString()
                    };
                    banks.Add(it);
                }
            }

            Banks = banks.ToArray();
        });
    }
}
