using System;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcNoCache = new CalcNoCache();
            var calcWithCache = new CalcWithCache();
            var calcServicewithCache = new CalcService(calcWithCache);
            var calcServiceNoCache = new CalcService(calcNoCache);
            
            calcServicewithCache.Calculate(45, 45);
            calcServicewithCache.Calculate(41, 12);
            calcServicewithCache.Calculate(45, 45);
            
            calcServiceNoCache.Calculate(32, 92);

            Console.ReadKey();

        }
    }
}
