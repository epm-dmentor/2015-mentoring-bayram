using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public class EmFeedProcessor : IFeedProcessor
    {
        private const int _additionalAssetValue =1000;        

        private const string feedType = "EM_FEED";
        public void ProcessFeedItems(IEnumerable<FeedItem> feeditems)
        {
            foreach (var item in feeditems)
            {
                Validate(item);
                Save(Match(item));
            }
        }

        public IEnumerable<ValidationError> Validate(FeedItem feeditem)
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

           
            emFeed.SourceAccountId = emFeed.SourceAccountId + feedType;
            emFeed.AssetGmv = emFeed.AssetGmv + _additionalAssetValue;
            return emFeed;
        }

        public virtual void Save(FeedItem matchedaccount)
        {
            Console.WriteLine("Saved account for EM Feed: {0}", matchedaccount.CounterpartyId);
        }
    }
}
