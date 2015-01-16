using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.RetailEquity
{
    public class BarclaysFilter:IFilter
    {
        private const string TradeType = "Option";
        private const string TradeSubType = "NyOption";
        private const int MaxTreshold = 50;
        
        public IEnumerable<Trade> Match(IEnumerable<Trade> trades)
        {
           return trades.Where(x => x.Type.Equals(TradeType) && x.SubType.Equals(TradeSubType) 
               && x.Amount > MaxTreshold).ToList();
        }
    }
}
