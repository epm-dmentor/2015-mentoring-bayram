namespace Epam.NetMentoring.CalculationService
{
    /// <summary>
    /// Class for custom type for storing in Cache.
    /// custom GetHashCode() method was overriden here to assign hashcode as a key in cache.
    /// </summary>
    
    public class CalcParameters:ICalcParameters
    {
        private readonly decimal _firstParameter;
        private readonly decimal _secondParameter;
        private readonly decimal _additionalParameter;
      
        public CalcParameters(decimal firstParam, decimal secondParam,ICalcParameters additionalParameters)
        
        {
            _firstParameter = firstParam;
            _secondParameter = secondParam;
            _additionalParameter = additionalParameters.AdditionalParameter;
            
        }

        public decimal FirstParameter
        {
            get { return _firstParameter; }
        }

        public decimal SecondParameter
        {
            get { return _secondParameter; }
        }

        public decimal AdditionalParameter
        {
            get { return _additionalParameter; }
        }

        public override int GetHashCode()
        {
            return _firstParameter.GetHashCode() ^ _secondParameter.GetHashCode() 
                  ^_additionalParameter.GetHashCode();
        }

        public bool Equals(ICalcParameters calcParameters)
        {
            if (calcParameters == null)
                return false;
            return (_firstParameter == calcParameters.FirstParameter &&
                    _secondParameter == calcParameters.SecondParameter && 
                    _additionalParameter==calcParameters.AdditionalParameter);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ICalcParameters))
                return false;

            return Equals((ICalcParameters)obj);
        }

 

       
    }
}
