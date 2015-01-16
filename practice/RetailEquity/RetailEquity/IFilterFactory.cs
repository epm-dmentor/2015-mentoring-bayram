namespace Epam.NetMentoring.RetailEquity
{
    public interface IFilterFactory
    {
        IFilter CreateFilter(string filtername);
    }
}
