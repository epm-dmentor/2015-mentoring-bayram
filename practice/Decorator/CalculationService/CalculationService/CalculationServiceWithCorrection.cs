namespace Epam.NetMentoring.CalculationService
{
    public class CalculationServiceWithCorrection:ICalculationService
    {
        private readonly decimal _value;
        private readonly ICalculationService _service;

        public CalculationServiceWithCorrection(decimal value, ICalculationService service)
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
