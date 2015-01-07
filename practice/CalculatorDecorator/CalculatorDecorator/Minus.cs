namespace Epam.NetMentoring.Calculator
{
    public class Minus:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Minus(IOperation operation,IOperation operation2)
        {
            _x = operation.GetResult();
            _y = operation2.GetResult();
        }

        public double GetResult()
        {
            return _x - _y;
        }
    }
}
