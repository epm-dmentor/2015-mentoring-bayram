namespace Epam.NetMentoring.RetailEquity
{
    public class BOFATrade:ITrade
    {
        private readonly string _type;
        private readonly string _subType;
        private readonly int _amount;

        public BOFATrade(string type, string subType, int amount)
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
