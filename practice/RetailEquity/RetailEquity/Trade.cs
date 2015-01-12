namespace Epam.NetMentoring.RetailEquity
{
    public class Trade:ITrade
    {
       private readonly string _type;
        private readonly string _subType;
        private readonly int _amount;

        public Trade(string type, string subType, int amount)
        {
            _type = type;
            _subType = subType;
            _amount = amount;
        }

        public string Type
        {
            get { return _type; }
        }

        public string SubType
        {
            get { return _subType; }
        }

        public int Amount
        {
            get { return _amount; }
        }
    }
}
