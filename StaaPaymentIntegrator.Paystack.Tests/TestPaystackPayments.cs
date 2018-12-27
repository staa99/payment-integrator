using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaaPaymentIntegrator.Paystack.Tests.TestUtilities;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Requests.Payment;
using Staaworks.PaymentIntegrator.Paystack.Implementations.Responses.Payment;
using static StaaPaymentIntegrator.Paystack.Tests.TestUtilities.TestConstants;

namespace StaaPaymentIntegrator.Paystack.Tests
{
    [TestClass]
    public class TestPaystackPayments
    {
        private readonly Staaworks.PaymentIntegrator.Paystack.Paystack paystack = new Staaworks.PaymentIntegrator.Paystack.Paystack(PaystackValidSecretKey);
        private readonly Staaworks.PaymentIntegrator.Paystack.Paystack paystackFakeKeys = new Staaworks.PaymentIntegrator.Paystack.Paystack(Guid.NewGuid().ToString());


        [TestInitialize]
        public void Initialize ()
        {
            paystack.InitializePayments(PaystackVerifyPaymentUrl, PaystackInitializePaymentUrl, PaystackChargeAuthorizationUrl, PaystackRequestReauthorizationUrl, PaystackCheckAuthorizationUrl);
            paystackFakeKeys.InitializePayments(PaystackVerifyPaymentUrl, PaystackInitializePaymentUrl, PaystackChargeAuthorizationUrl, PaystackRequestReauthorizationUrl, PaystackCheckAuthorizationUrl);
        }

        [TestMethod]
        public async Task IsInitializePaymentParsingCorrect ()
        {
            paystack.Caller = new TestPaystackCaller<PaymentInitializationResponse>();
            const string expectedMessage = "Authorization URL created";
            const string expectedStatus = "success";

            var request = new PaymentInitializationRequest
            {
                Amount = 50000,
                Reference = "500",
                Email = "a@b.c",
                CallbackUrl = "https://callback.test.com/endpoint"
            };

            var response = await paystack.MakePayment(request);

            Assert.AreEqual(expectedMessage, response.Message);
            Assert.AreEqual(expectedStatus, response.Status);
            Assert.IsTrue(response.AuthorizationUrl != null);
        }


        [TestMethod]
        public async Task IsVerifyPaymentSuccessParsingCorrect()
        {
            paystack.Caller = new TestPaystackCaller<PaymentVerificationResponse>();
            const string expectedMessage = "Successful";
            const string expectedStatus = "success";

            var request = new PaymentVerificationRequest("500");

            var response = await paystack.VerifyPayment(request);

            Assert.AreEqual(expectedMessage, response.Message);
            Assert.AreEqual(expectedStatus, response.Status);
            Assert.IsTrue(response.AuthorizationReference != null);
            Assert.IsTrue(response.Successful);
        }
    }
}
