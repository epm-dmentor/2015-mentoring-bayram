namespace Epam.NetMentoring.Calculator
{
    public class Plus:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Plus(IOperation operation, IOperation operation2)
        {
            _x = operation.GetResult();
            _y = operation2.GetResult();
        }
        
        public double GetResult()
        {
            return _x + _y;
        }
    }
}
