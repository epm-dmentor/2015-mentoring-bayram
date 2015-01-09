namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Concrete implementation. Calculation without cache.
    /// </summary>
    /// 
    public class CalcNoCache:IService
    {
        private readonly decimal _additionalParam;

        public CalcNoCache(decimal additionalParam)
        {
            _additionalParam = additionalParam;
        }
        
        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return firstParameter*firstParameter + 2*firstParameter
                   *secondParameter*secondParameter*secondParameter+_additionalParam;

        }
    }
}
