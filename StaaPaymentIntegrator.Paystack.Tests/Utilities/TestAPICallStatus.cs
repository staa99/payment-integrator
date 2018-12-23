using Microsoft.VisualStudio.TestTools.UnitTesting;
using Staaworks.PaymentIntegrator.Paystack.Utilities;

namespace Staaworks.PaymentIntegrator.Paystack.Tests.Utilities
{
    [TestClass]
    public class TestAPICallStatus
    {
        [TestMethod]
        public void TestDefaultStatus () => Assert.AreEqual(default(APICallStatus), APICallStatus.failed);
    }
}
