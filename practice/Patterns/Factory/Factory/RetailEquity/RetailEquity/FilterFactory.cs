namespace Epam.NetMentoring.RetailEquity
{
    public class FilterFactory:IFilterFactory
    {
        public IFilter CreateFilter(string filtername)
        {
            switch (filtername)
            {
                case "Barclays": return new BarclaysFilter();
                case "Bofa": return new BOFAFilter();
                case "Connacord": return new ConnacordFilter();
                default: return new DefaultFilter();
            }
        }
    }
}
