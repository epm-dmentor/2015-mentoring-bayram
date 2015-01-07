namespace Epam.NetMentoring.CalculationService
{
    public class CalcService:IService
    {
        private readonly IService _service;

        public CalcService(IService service)
        {
            _service = service;
        }
        
        public decimal Calculate(decimal firstParam, decimal secondParam)
        {
            return _service.Calculate(firstParam, secondParam);
        }
    }
}
