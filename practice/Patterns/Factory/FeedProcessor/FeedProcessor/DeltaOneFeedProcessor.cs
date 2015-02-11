using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOneFeedProcessor:IFeedProcessor
    {
        public virtual IEnumerable<ValidationError> Validate(FeedItem feeditem)
        {
            var validationErrors = new List<ValidationError>();
            
            if (feeditem.CounterpartyId == 0)
            {
               validationErrors.Add(new ValidationError{ErrorMessage = "CounterpartyId must not be 0"});
            }
            if (feeditem.PrincipalId == 0)
            {
                validationErrors.Add(new ValidationError { ErrorMessage = "PrincipalId must not be 0" });
            }

            return validationErrors;

        }

        public virtual FeedItem Match(FeedItem feeditem)
        {

            var deltaFeed = feeditem as DeltaOne;
            
            if (deltaFeed == null) throw new Exception("Not Supported FeedItem for processing DeltaOne.");
            deltaFeed.CounterpartyId = deltaFeed.CounterpartyId + deltaFeed.PrincipalId;
            return deltaFeed;
        }

        public virtual void Save(FeedItem matchedaccount)
        {
            Console.WriteLine("Saved account for DeltaOne Feed {0}", matchedaccount.CounterpartyId);
        }
    }
}
