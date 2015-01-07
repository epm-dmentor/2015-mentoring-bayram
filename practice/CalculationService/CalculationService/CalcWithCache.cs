using System.Collections.Generic;

namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Concrete Implementation of IService interface;
    /// Calculation with cache option is implemented below
    /// </summary>

    public class CalcWithCache:IService
    {
        private Dictionary<int, CalcParameters> _cache;

        public CalcWithCache()
        {
            _cache = new Dictionary<int, CalcParameters>();
        }

        public decimal Calculate(decimal firstParam, decimal secondParam)
        {
            var calcParameters = new CalcParameters(firstParam, secondParam);
            var key = calcParameters.GetHashCode();
            
            if (_cache.ContainsKey(key)) return _cache[key].Result;
            
            var result = firstParam * firstParam + 2 * firstParam * secondParam * secondParam * secondParam;
            calcParameters.Result = result;
            _cache.Add(key, calcParameters);
            
            return result;
        }
    }
}
