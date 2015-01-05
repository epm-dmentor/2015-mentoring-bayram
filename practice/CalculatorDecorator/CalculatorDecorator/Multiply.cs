namespace CalculatorDecorator
{
    public class Multiply:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Multiply(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Multiply(double x, IOperation operation)
        {
            _x = x;
            _y = operation.GetResult();
        }
        
        public double GetResult()
        {
            return _x * _y;
        }
    }
}
