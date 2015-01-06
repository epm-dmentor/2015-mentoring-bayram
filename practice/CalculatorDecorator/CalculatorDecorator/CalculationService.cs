using System;
using System.Collections.Generic;
using System.Threading;

namespace Epam.NetMentoring.Calculator
{
    //IT: Move to another project
    public class CalculationService
    {
        private Dictionary<Tuple<decimal,decimal>,decimal> _cache;

        public CalculationService()
        {
            _cache = new Dictionary<Tuple<decimal, decimal>, decimal>();
        }

        protected decimal CheckCache(decimal a, decimal b)
        {
            var inputParameters = new Tuple<decimal, decimal>(a,b);
            
            if (_cache.ContainsKey(inputParameters))
                return _cache[inputParameters];
            
            var value = a*a + 2*a*b*b*b;
            _cache.Add(inputParameters,value);
            return value;

        }
        
        public decimal Calculate(decimal a, decimal b)
        {

            Thread.Sleep(1000);
            return CheckCache(a, b);
        }



    }
}
