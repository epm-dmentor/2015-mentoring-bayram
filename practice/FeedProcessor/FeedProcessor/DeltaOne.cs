using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOne:IFeedItem
    {
        private readonly decimal _stagingId;
        private readonly string _sourceTradeRef;
        private readonly decimal _counterpartyId;
        private readonly decimal _principalId;
        private readonly DateTime _valuationDate;
        private readonly decimal _currentPrice;
        private readonly decimal _sourceAccountId;
        private readonly decimal _tradeIdentifier;
        private readonly DateTime _maturityDate;

        public DeltaOne(decimal stagingId, string sourceTradeRef, decimal counterpartyId, decimal principalId,
            DateTime valuationDate, decimal currentprice, decimal sourceAccountId, decimal tradeIdentifier, DateTime maturityDate)
        {
            _stagingId = stagingId;
            _sourceTradeRef = sourceTradeRef;
            _counterpartyId = counterpartyId;
            _principalId = principalId;
            _valuationDate = valuationDate;
            _currentPrice = currentprice;
            _sourceAccountId = sourceAccountId;
            _tradeIdentifier = tradeIdentifier;
            _maturityDate = maturityDate;

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

        public decimal TradeIdentifier
        {
            get { return _tradeIdentifier; }
        }
        public DateTime MaturityDate
        {
            get { return _maturityDate; }
        }

    }
}
