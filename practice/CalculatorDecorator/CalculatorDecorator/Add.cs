namespace Epam.NetMentoring.Calculator
{
    public class Add : IOperation
    {
        private readonly IOperation _leftOperand;
        private readonly IOperation _rightOperand;

        public Add(IOperation leftOperand, IOperation rightOperand)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;            
        }

        public double GetResult()
        {
            var x = _leftOperand.GetResult();
            var y = _rightOperand.GetResult();
            return x + y;
        }
    }

   


}
