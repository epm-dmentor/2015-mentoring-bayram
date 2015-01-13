using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOneFeedProcessor:IFeedProcessor
    {
        private List<IFeedItem> _feedItems;

        public void ProcessFeedItems(List<IFeedItem> feeditems)
        {

            _feedItems = feeditems;

            for (var i = 0; i < _feedItems.Count / 5 + 1; i++)
            {
                var fiveitems = _feedItems.Skip(i * 5).Take(5);
                foreach (var item in fiveitems)
                {
                    Validate(item);
                    Save(Match(item));
                }
            }

        }

        public void Validate(IFeedItem feeditem)
        {
            if (feeditem.CounterpartyId == 0)
            {
                throw new InvalidCounterpartyException("Counterparty should not be 0");
            }

            Console.WriteLine("Validation for "+ feeditem.CounterpartyId);
        }

        public string Match(IFeedItem feeditem)
        {
            return feeditem.CounterpartyId + feeditem.PrincipalId.ToString();
        }

        public void Save(string matchedaccount)
        {
            Console.WriteLine("Saved account {0}", matchedaccount);
        }
    }
}
