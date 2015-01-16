using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class ConnacordFilter:IFilter
    {
        private const string TradeType="Future";
        private const int MinTreshold = 10;
        private const int MaxTreshold = 40;

        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
            return trades.Where(x => x.Type.Equals(TradeType) && x.Amount > MinTreshold && x.Amount<MaxTreshold).ToList();
        }
    }
}
