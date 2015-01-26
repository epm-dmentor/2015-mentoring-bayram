using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    //IT: the same commenst as for DeltaOneProcessor
    public class EmFeedProcessor:IFeedProcessor
    {
        public void ProcessFeedItems(IEnumerable<FeedItem> feeditems)
        {
            foreach (var item in feeditems)
            {
                Validate(item);
                Save(Match(item));
            }
        }

        public virtual IEnumerable<ValidationError> Validate(FeedItem feeditem)
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

            return validationErrors;
        }

        public virtual FeedItem Match(FeedItem feeditem)
        {
            feeditem.SourceAccountId = feeditem.SourceAccountId + "EM_FEED";
            return feeditem;
        }

        public virtual void Save(FeedItem matchedaccount)
        {
            Console.WriteLine("Saved account for EM Feed: {0}", matchedaccount.CounterpartyId);
        }
    }
}
