using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BarclaysFilter:IFilter
    {
        public IEnumerable<ITrade> Match(List<ITrade> trades)
        {
           return trades.Where(x => x.Type.Equals("Option") && x.SubType.Equals("NyOption") && x.Amount > 50).ToList();
        }
    }
}
