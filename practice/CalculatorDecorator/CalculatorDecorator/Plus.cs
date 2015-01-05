namespace CalculatorDecorator
{
    public class Plus:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Plus(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public Plus(double x, IOperation operation)
        {
            _x = x;
            _y = operation.GetResult();
        }

        public double GetResult()
        {
            return _x + _y;
        }
    }
}
