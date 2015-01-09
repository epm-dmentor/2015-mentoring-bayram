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
            var calc = new CalcNoCache();
            var calcWithCache = new CalcWithCache(calc);
            const decimal expected = 8203275;
            var actual = calcWithCache.Calculate(new CalcParameters(45,45,new AdditionalCalcParams(0)));
            Assert.AreEqual(expected,actual);

        }
        
    }
}
