using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BOFAFilter:IFilter
    {
        private const int MaxTreshold = 70;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(x => x.Amount > MaxTreshold);
        }
    }
}
