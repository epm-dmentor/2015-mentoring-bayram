namespace Epam.NetMentoring.RetailEquity
{
    public class BankFactory
    {
        public ITrade FilterTrade(string type, string subType, int amount)
        {
            if (amount > 70)
            {
                return new BOFATrade(type,subType,amount);
            }
            if (type.Equals("Future") && amount > 10 && amount < 40)
            {
                return new ConnacordTrade(type,subType,amount);
            }
            if (type.Equals("Option") && subType.Equals("NyOption") && amount > 50)
            {
                return new BarclaysTrade(type,subType,amount);
            }
            throw new UnknownTradeException("Your trade do not satisfy any known conditions...");
        }
    }
}
