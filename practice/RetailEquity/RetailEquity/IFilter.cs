using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    public interface IFilter
    {
        IEnumerable<ITrade> Match(List<ITrade> trades);
    }
}
