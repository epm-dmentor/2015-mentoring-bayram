namespace Epam.NetMentoring.RetailEquity
{
    public interface ITrade
    {
        string Type { get; }
        string SubType { get; }
        int Amount { get; }
    }
}
