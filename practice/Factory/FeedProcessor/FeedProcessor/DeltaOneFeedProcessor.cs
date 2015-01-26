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
            feeditem.CounterpartyId = feeditem.CounterpartyId + feeditem.PrincipalId;
            return feeditem;
        }

        public virtual void Save(FeedItem matchedaccount)
        {
            //IT: must be more evident comment: Saved Delta1 feed (not account)
            Console.WriteLine("Saved account for DeltaOne Feed {0}", matchedaccount.CounterpartyId);
        }
    }
}
