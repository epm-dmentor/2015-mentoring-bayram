namespace Epam.NetMentoring.CalculationService
{
    public interface ICalcParameters
    {
        decimal FirstParameter { get; }
        decimal SecondParameter { get; }
        decimal AdditionalParameter { get; }
    }
}
