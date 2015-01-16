using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOneFeedProcessor:IFeedProcessor
    {
        public void ProcessFeedItems(IEnumerable<FeedModel> feeditems)
        {
            var feedModels = feeditems as IList<FeedModel> ?? feeditems.ToList();
            foreach (var item in feedModels)
            {
                Validate(item);
                Save(Match(item));
            }
        }

        protected virtual void Validate(FeedModel feeditem)
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

            if (validationErrors.Count > 0)

                throw new InvalidCounterpartyException("Please check validation errors in log...");

        }

        protected virtual FeedModel Match(FeedModel feeditem)
        {
            feeditem.CounterpartyId = feeditem.CounterpartyId + feeditem.PrincipalId;
            return feeditem;
        }

        protected virtual void Save(FeedModel matchedaccount)
        {
            Console.WriteLine("Saved account {0}", matchedaccount.CounterpartyId);
        }
    }
}
