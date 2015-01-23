using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.FeedProcessor
{
    //IT: the same commenst as for DeltaOneProcessor
    public class EmFeedProcessor:IFeedProcessor
    {
        public void ProcessFeedItems(IEnumerable<FeedItem> feeditems)
        {
            var feedModels = feeditems as IList<FeedItem> ?? feeditems.ToList();
            foreach (var item in feedModels)
            {
                Validate(item);
                Save(Match(item));
            }
        }

        protected virtual void Validate(FeedItem feeditem)
        {
            var validationErrors = new List<ValidationError>();

            if (feeditem.CounterpartyId == 0)
            {
                validationErrors.Add(new ValidationError { ErrorMessage = "CounterpartyId must not be 0" });
            }
            if (feeditem.PrincipalId == 0)
            {
                validationErrors.Add(new ValidationError { ErrorMessage = "PrincipalId must not be 0" });
            }
            
            if (validationErrors.Count>0)
            
            throw new InvalidCounterpartyException("Please check validation errors in log...");

        }

        protected virtual FeedItem Match(FeedItem feeditem)
        {
            feeditem.SourceAccountId = feeditem.SourceAccountId + "EM_FEED";
            return feeditem;
        }

        protected virtual void Save(FeedItem matchedaccount)
        {
            Console.WriteLine("Saved account {0}", matchedaccount.CounterpartyId);
        }
    }
}
