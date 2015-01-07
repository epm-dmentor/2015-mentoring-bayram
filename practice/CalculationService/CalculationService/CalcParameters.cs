namespace Epam.NetMentoring.CalculationService
{

    /// <summary>
    /// Class for custom type for storing in Cache.
    /// custom GetHashCode() method was overriden here to assign hashcode as a key in cache.
    /// Result Field is accessable to modify in order to prevent calculation when checking cache.
    /// </summary>
    public class CalcParameters
    {
        private readonly decimal _firstParameter;
        private readonly decimal _secondParameter;

        public CalcParameters(decimal firstParam, decimal secondParam)
        {
            _firstParameter = firstParam;
            _secondParameter = secondParam;
            
        }

        public decimal FirstParameter
        {
            get { return _firstParameter; }
        }

        public decimal SecondParameter
        {
            get { return _secondParameter; }
        }

        public decimal Result { get; set; }

        public override int GetHashCode()
        {
            return _firstParameter.GetHashCode() ^ _secondParameter.GetHashCode();
        }
    }
}
