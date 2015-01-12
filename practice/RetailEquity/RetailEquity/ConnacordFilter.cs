using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class ConnacordFilter:IFilter
    {
        public IEnumerable<ITrade> Match(List<ITrade> trades)
        {
            return trades.Where(x => x.Type.Equals("Future") && x.Amount > 10 && x.Amount<40).ToList();
        }
    }
}
