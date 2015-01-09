namespace Epam.NetMentoring.CalculationService
{
    public class AdditionalCalcParams:ICalcParameters
    {
        private readonly decimal _parameter;

        public AdditionalCalcParams(decimal param)
        {
            _parameter = param;
        }

        public decimal AdditionalParameter
        {
            get { return _parameter; }
        }


        public decimal FirstParameter
        {
            get { throw new System.NotImplementedException(); }
        }

        public decimal SecondParameter
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
