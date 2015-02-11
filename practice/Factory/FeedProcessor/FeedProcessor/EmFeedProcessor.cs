using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
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

        //IT: it might be virtual, but might be not. As usual Em is a concrete implementation, 
        //and it is better to not mark it as virtual (it would be reasonable to do that for some base class: FeedProcessor)
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
            var emFeed = feeditem as EmFeed;
            
            if (emFeed == null) throw new Exception("Not Supported FeedItem for processing EMFeed");

            //IT: it's always better to use constant instead of values
            emFeed.SourceAccountId = emFeed.SourceAccountId + "EM_FEED";
            emFeed.AssetGmv = emFeed.AssetGmv + 1000;
            return emFeed;
        }

        public virtual void Save(FeedItem matchedaccount)
        {
            Console.WriteLine("Saved account for EM Feed: {0}", matchedaccount.CounterpartyId);
        }
    }
}
