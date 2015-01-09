namespace Epam.NetMentoring.CalculationService
{
    /// <summary>
    /// Class for custom type for storing in Cache.
    /// custom GetHashCode() method was overriden here to assign hashcode as a key in cache.
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

        public override int GetHashCode()
        {
            return _firstParameter.GetHashCode() ^ _secondParameter.GetHashCode();
        }

        public bool Equals(CalcParameters calcParameters)
        {
            if (calcParameters == null)
                return false;
            return (_firstParameter == calcParameters.FirstParameter &&
                    _secondParameter == calcParameters.SecondParameter);
        }

        public override bool Equals(object obj)
        {
            var param = obj as CalcParameters;

            if (param == null) return false;
            
            return Equals((CalcParameters)obj);
        }

    }
}
