using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BOFAFilter:IFilter
    {
        public IEnumerable<ITrade> Match(List<ITrade> trades)
        {
            return trades.Where(x => x.Amount > 70).ToList();
        }
    }
}
