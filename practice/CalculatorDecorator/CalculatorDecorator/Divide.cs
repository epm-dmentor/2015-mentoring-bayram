using System;

namespace CalculatorDecorator
{
    public class Divide:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Divide(double x, double y)
        {
            _x = x;
            _y = y;
        }
        
        public Divide(double x, IOperation operation)
        {
            _x = x;
            _y = operation.GetResult();
        }
        
        public double GetResult()
        {
            if (_y != 0) return _x / _y;
            throw  new DivideByZeroException();
        }
    }
}
