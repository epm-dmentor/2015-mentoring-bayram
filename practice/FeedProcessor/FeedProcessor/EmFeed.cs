using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class EmFeed:IFeedItem
    {
        private readonly decimal _stagingId;
        private readonly string _sourceTradeRef;
        private readonly decimal _counterpartyId;
        private readonly decimal _principalId;
        private readonly DateTime _valuationDate;
        private readonly decimal _currentPrice;
        private readonly decimal _sourceAccountId;
        private readonly decimal _assetValue;
        private readonly decimal _assetGmv;

        public EmFeed(decimal stagingId, string sourceTradeRef, decimal counterpartyId, decimal principalId,
            DateTime valuationDate, decimal currentprice, decimal sourceAccountId, decimal assetValue, decimal assetGmv)
        {
            _stagingId = stagingId;
            _sourceTradeRef = sourceTradeRef;
            _counterpartyId = counterpartyId;
            _principalId = principalId;
            _valuationDate = valuationDate;
            _currentPrice = currentprice;
            _sourceAccountId = sourceAccountId;
            _assetValue = assetValue;
            _assetGmv = assetGmv;

        }
        
        public decimal StagingId
        {
            get { return _stagingId; }
        }

        public string SourceTradeRef
        {
            get { return _sourceTradeRef; }
        }

        public decimal CounterpartyId
        {
            get { return _counterpartyId; }
        }

        public decimal PrincipalId
        {
            get { return _principalId; }
        }

        public DateTime ValuationDate
        {
            get { return _valuationDate; }
        }

        public decimal CurrentPrice
        {
            get { return _currentPrice; }
        }

        public decimal SourceAccountId
        {
            get { return _sourceAccountId; }
        }

        public decimal AssetValue
        {
            get { return _assetValue; }
        }
        public decimal AssetGmv
        {
            get { return _assetGmv; }
        }
    }
}
