namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Concrete implementation. Calculation without cache.
    /// </summary>
    /// 
    public class CalcNoCache:IService
    {
        public decimal Calculate(ICalcParameters calcParameters)
        {
            return calcParameters.FirstParameter*calcParameters.FirstParameter + 2*calcParameters.FirstParameter
                   *calcParameters.SecondParameter*calcParameters.SecondParameter*calcParameters.SecondParameter
                   +calcParameters.AdditionalParameter;
        }
    }
}
