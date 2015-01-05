using System;

namespace CalculatorDecorator
{
    public class Divide:IOperation
    {
        private readonly double _x;
        private readonly double _y;

        public Divide(IOperation operation, IOperation operation2)
        {
            _x = operation.GetResult();
            _y = operation2.GetResult();
        }

        public double GetResult()
        {
            if (_y != 0) return _x / _y;
            throw  new DivideByZeroException();
        }
    }
}
