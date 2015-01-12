using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                default: return new BarclaysFilter();
            }
        }
    }
}
