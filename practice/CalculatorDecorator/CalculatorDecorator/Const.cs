namespace Epam.NetMentoring.Calculator
{
    public class Const:IOperation
    {
        private readonly double _x;

        public Const(double x)
        {
            _x = x;
        }

        public double GetResult()
        {
            return _x;
        }
    }
}
