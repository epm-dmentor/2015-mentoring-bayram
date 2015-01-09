using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Concrete Implementation of IService interface;
    /// Calculation with cache option is implemented below
    /// </summary>

    public class CalcWithCache:IService
    {
        private readonly Dictionary<ICalcParameters, decimal> _cache = new Dictionary<ICalcParameters, decimal>();
        private readonly IService _service;
        
        public CalcWithCache(IService service)
        {
            _service = service;
        }

        public decimal Calculate(ICalcParameters calcParameters)
        {
           
            if (_cache.Keys.Contains(calcParameters)) return _cache[calcParameters];

            var result = _service.Calculate(calcParameters);
            
            _cache.Add(calcParameters,result);
            
            return result;
        }
    }
}
