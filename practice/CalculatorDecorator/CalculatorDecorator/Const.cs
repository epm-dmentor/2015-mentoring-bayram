namespace CalculatorDecorator
{
    public class Const:IOperation
    {
        private double _x;

        public Const(double x)
        {
            this._x = x;
        }

        public double GetResult()
        {
            return _x;
        }
    }
}
