using System;

namespace Epam.NetMentoring.Calculator
{
    public class Divide:IOperation
    {
        //IT: it's better to save operand instead
        private readonly double _x;
        private readonly double _y;

        public Divide(IOperation operation, IOperation operation2)
        {
            //IT: move calc to getresult
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
