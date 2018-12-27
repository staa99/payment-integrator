using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaaPaymentIntegrator.Paystack.Tests.TestUtilities;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Banks;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Banks;
using static StaaPaymentIntegrator.Paystack.Tests.TestUtilities.TestConstants;

namespace StaaPaymentIntegrator.Paystack.Tests
{
    [TestClass]
    public class TestPaystackBanks
    {
        private readonly Staaworks.PaymentIntegrator.Paystack.Paystack paystack = new Staaworks.PaymentIntegrator.Paystack.Paystack(PaystackValidSecretKey);
        private readonly Staaworks.PaymentIntegrator.Paystack.Paystack paystackFakeKeys = new Staaworks.PaymentIntegrator.Paystack.Paystack(Guid.NewGuid().ToString());


        [TestInitialize]
        public void Initialize ()
        {
            paystack.InitializeBanks(PaystackGetBanksUrl, PaystackResolveAccountNameUrl);
            paystackFakeKeys.InitializeBanks(PaystackGetBanksUrl, PaystackResolveAccountNameUrl);
        }


        [TestMethod]
        public async Task IsBankListParsingCorrect ()
        {
            paystack.Caller = new TestPaystackCaller<BanksResponse>();
            const string expectedMessage = "Banks retrieved";
            const string expectedStatus = "success";
            const int expectedBankCount = 2;
            const string expectedBankCode1 = "044";
            const string expectedBankCode2 = "023";

            var response = await paystack.GetBanks();

            Assert.AreEqual(expectedMessage, response.Message);
            Assert.AreEqual(expectedStatus, response.Status);
            Assert.AreEqual(expectedBankCount, response.Banks.Length);
            Assert.AreEqual(expectedBankCode1, response.Banks[0].Reference);
            Assert.AreEqual(expectedBankCode2, response.Banks[1].Reference);
        }


        [TestMethod]
        public async Task IsBankAccountNameResolutionParsingCorrect ()
        {
            paystack.Caller = new TestPaystackCaller<BankAccountNameQueryResponse>();
            const string expectedMessage = "Account number resolved";
            const string expectedStatus = "success";
            const string expectedAccountName = "staa";
            const string expectedAccountNumber = "0241904090";
            const string bankReference = "058";

            var request = new BankAccountNameQueryRequest(expectedAccountNumber, bankReference);

            var response = await paystack.QueryAccountName(request);

            Assert.AreEqual(expectedMessage, response.Message);
            Assert.AreEqual(expectedStatus, response.Status);
            Assert.AreEqual(expectedAccountName, response.AccountName);
            Assert.AreEqual(expectedAccountNumber, response.AccountNumber);
        }


        [TestMethod]
        public async Task IsBankListErrorResponseHandlingCorrect ()
        {
            paystackFakeKeys.Caller = new TestPaystackCaller<BanksResponse>();
            const string expectedStatus = "failed";
            const int expectedBankCount = 0;

            var response = await paystackFakeKeys.GetBanks();
            Assert.AreEqual(expectedStatus, response.Status);
            Assert.AreEqual(expectedBankCount, response.Banks.Length);
        }
    }
}
