using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaaPaymentIntegrator.Paystack.Utilities;

namespace StaaPaymentIntegrator.Paystack.Tests.Utilities
{
    [TestClass]
    public class TestAPICallStatus
    {
        [TestMethod]
        public void TestDefaultStatus () => Assert.AreEqual(default(APICallStatus), APICallStatus.failed);
    }
}
