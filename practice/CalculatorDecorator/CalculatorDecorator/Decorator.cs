namespace CalculatorDecorator
{
    public abstract class Decorator
    {
        protected Decorator(IOperation operation,IOperation operation2)
        {
           
        }
        protected Decorator(double x, IOperation operation)
        {
           
        }
        protected Decorator(IOperation operation, double y)
        {

        }

        public abstract double GetResult();
    }

    public class Add : Decorator
    {
        private double _x;
        private double _y;
        
        public Add(IOperation operation,IOperation operation2) : base(operation,operation2)
        {
            this._x= operation.GetResult();
            this._y = operation2.GetResult();
        }

        public Add(double x, IOperation operation2)
            : base(x, operation2)
        {
            this._x = x;
            this._y = operation2.GetResult();
        }

        public Add(IOperation operation,double y)
            : base(operation,y)
        {
            this._x = operation.GetResult();
            this._y = y;
        }

        public override double GetResult()
        {
            return _x + _y;
        }
    }

   


}
