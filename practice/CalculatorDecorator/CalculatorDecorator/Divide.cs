using System;

namespace Epam.NetMentoring.Calculator
{
    public class Divide:IOperation
    {
        private readonly IOperation _leftOperand;
        private readonly IOperation _rightOperand;

        public Divide(IOperation leftOperand, IOperation rightOperand)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }

        public double GetResult()
        {
            var x = _leftOperand.GetResult();
            var y = _rightOperand.GetResult();
            if (y != 0) return x / y;
            throw  new DivideByZeroException();
        }
    }
}
