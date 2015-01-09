using System.Collections.Generic;

namespace Epam.NetMentoring.CalculationService
{
    /// <summary>
    /// Concrete Implementation of IService interface;
    /// Calculation with cache option is implemented below
    /// </summary>

    public class CalcWithCache:IService
    {
        private readonly Dictionary<CalcParameters, decimal> _cache = new Dictionary<CalcParameters, decimal>();
        private readonly IService _service;
        
        public CalcWithCache(IService service)
        {
            _service = service;
        }

        public decimal Calculate(decimal firstParam,decimal secondParam)
        {
            var calcParameters = new CalcParameters(firstParam, secondParam);
            
            if (_cache.ContainsKey(calcParameters)) return _cache[calcParameters];

            var result = _service.Calculate(firstParam,secondParam);
            
            _cache.Add(calcParameters,result);
            
            return result;
        }
    }
}
