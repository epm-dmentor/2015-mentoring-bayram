namespace Epam.NetMentoring.Calculator
{
    public class Multiply:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Multiply(IOperation operation, IOperation operation2)
        {
            _x = operation.GetResult();
            _y = operation2.GetResult();
        }
        
        public double GetResult()
        {
            return _x * _y;
        }
    }
}
