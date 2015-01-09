namespace Epam.NetMentoring.CalculationService
{
    public class AdditionalCalc:IService
    {
        private readonly decimal _value;
        private readonly IService _service;

        public AdditionalCalc(decimal value,IService service)
        {
            _service = service;
            _value = value;
        }

        public decimal Calculate(decimal firstParam, decimal secondParam)
        {
            return _service.Calculate(firstParam, secondParam) + _value;
        }
    }
}
