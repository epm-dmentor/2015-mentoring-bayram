using System;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcNoCache = new CalcNoCache();
            var calcNoCachewithout = new CalcNoCache();
            
            var additionalcalc = new AdditionalCalc(10, calcNoCache);
            var res = additionalcalc.Calculate(45, 45);

            var calcWithCache = new CalcWithCache(calcNoCache);
            var calcWithCache1 = new CalcWithCache(calcNoCachewithout);
            var result = calcWithCache.Calculate(45, 45);
            var result1 = calcWithCache.Calculate(45, 45);
            var result2 = calcWithCache1.Calculate(45, 45);
            var result3 = calcWithCache1.Calculate(45, 45);
            
            
            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadKey();

        }
    }
}
