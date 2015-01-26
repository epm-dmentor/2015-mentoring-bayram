using System.Collections.Generic;
namespace Epam.NetMentoring.CalculationService
{
    /// <summary>
    /// Concrete Implementation of IService interface;
    /// Calculation with cache option is implemented below
    /// </summary>

    public class CachedCalculationService:ICalculationService
    {
        private readonly Dictionary<CalculationParameters, decimal> _cache = 
                     new Dictionary<CalculationParameters, decimal>();
        
        private readonly ICalculationService _service;
        
        public CachedCalculationService(ICalculationService service)
        {
            _service = service;
        }

        public decimal Calculate(decimal firstParam,decimal secondParam)
        {
            var calcParameters = new CalculationParameters(firstParam, secondParam);
            
            if (_cache.ContainsKey(calcParameters)) return _cache[calcParameters];

            var result = _service.Calculate(firstParam,secondParam);
            
            _cache.Add(calcParameters,result);
            
            return result;
        }
    }
}
