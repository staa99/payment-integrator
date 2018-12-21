using System;
using System.Net;
using System.Threading.Tasks;
using StaaPaymentIntegrator.Paystack.Implementations.Responses.Banks;
using StaaPaymentIntegrator.Paystack.Utilities;
using Staaworks.PaymentIntegrator.Interfaces.Requests.Banks;
using Staaworks.PaymentIntegrator.Interfaces.Responses.Banks;
using Staaworks.PaymentIntegrator.Providers;

namespace StaaPaymentIntegrator.Paystack
{
    public partial class Paystack : IBanksProvider
    {
        public string BanksListUrl { get; private set; }

        public string BankAccountNameQueryUrl { get; private set; }

        /// <summary>
        /// Initialize paystack for miscellaneous bank operations
        /// </summary>
        /// <param name="banksListUrl">The URL to query a list of banks</param>
        /// <param name="bankAccountNameQueryUrl">The URL to use in resolving bank account names</param>
        public void InitializeBanks (string banksListUrl, string bankAccountNameQueryUrl)
        {
            BanksListUrl = banksListUrl;
            BankAccountNameQueryUrl = bankAccountNameQueryUrl;
        }

        #region Get Banks
        public Task<IBanksResponse> GetBanks () =>
            PaystackCall<IBanksResponse>.Get(BanksListUrl, SecretKey, OnGetBanksError, OnGetBanksResult);

        private async Task<IBanksResponse> OnGetBanksResult (string json, HttpStatusCode statusCode)
        {
            var response = new BanksResponse();
            await response.Parse(json);
            return response;
        }

        private Task<IBanksResponse> OnGetBanksError (Exception ex) => throw new Exception("An error occurred while getting banks from the Paystack API", ex);
        #endregion

        #region Query Account Name
        public Task<IBankAccountNameQueryResponse> QueryAccountName (IBankAccountNameQueryRequest request) =>
            PaystackCall<IBankAccountNameQueryResponse>.Get(BankAccountNameQueryUrl + request.Serialize().Result, SecretKey, OnQueryAccountNameError, OnQueryAccountNameResult);

        private async Task<IBankAccountNameQueryResponse> OnQueryAccountNameResult (string json, HttpStatusCode statusCode)
        {
            var response = new BankAccountNameQueryResponse();
            await response.Parse(json);
            return response;
        }

        private Task<IBankAccountNameQueryResponse> OnQueryAccountNameError (Exception ex) => throw new Exception("An error occurred while querying the account name from the Paystack API", ex);
        #endregion
    }
}