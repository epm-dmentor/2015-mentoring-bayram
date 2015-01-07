namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Concrete implementation. Calculation without cache.
    /// </summary>
    /// 
    public class CalcNoCache:IService
    {
        public decimal Calculate(decimal firstParam, decimal secondParam)
        {
            return firstParam * firstParam + 2 * firstParam * secondParam * secondParam * secondParam;
        }
    }
}
