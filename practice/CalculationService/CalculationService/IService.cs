namespace Epam.NetMentoring.CalculationService
{
    public interface IService
    {
        decimal Calculate(ICalcParameters calcParams);
    }
}
