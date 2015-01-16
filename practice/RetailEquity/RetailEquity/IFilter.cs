using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    public interface IFilter
    {
        IEnumerable<Trade> Match(IEnumerable<Trade> trades);
    }
}
