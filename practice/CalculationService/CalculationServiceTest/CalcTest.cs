using Epam.NetMentoring.CalculationService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epam.NetMentoring.CalculationServiceTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestCalcWithCache()
        {
            var calcWithCache = new CalcWithCache();
            var calcServicewithCache = new CalcService(calcWithCache);
            const decimal expected = 8203275;
            var actual = calcServicewithCache.Calculate(45, 45);
            Assert.AreEqual(expected,actual);

        }
        [TestMethod]
        public void TestCalcNoCache()
        {
            var calcNoCache = new CalcNoCache();
            var calcServiceNoCache = new CalcService(calcNoCache);
            const decimal expected = 8203275;
            var actual = calcServiceNoCache.Calculate(45, 45);
            Assert.AreEqual(expected, actual);

        }
    }
}
