using System;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcNoCache = new CalcNoCache();
            
            var calcWithCache = new CalcWithCache(calcNoCache);

            var result = calcWithCache.Calculate(new CalcParameters(45, 45, new AdditionalCalcParams(0)));
            var result1 = calcWithCache.Calculate(new CalcParameters(45, 45,new AdditionalCalcParams(0)));
            var result2 = calcWithCache.Calculate(new CalcParameters(45, 45, new AdditionalCalcParams(20)));
            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();

        }
    }
}
