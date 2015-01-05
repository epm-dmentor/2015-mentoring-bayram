using System;

namespace CalculatorDecorator
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = new Add(new Multiply(12, 3), new Plus(2,new Divide(12,3))).GetResult();
            
            Console.WriteLine(result);
            
            Console.ReadKey();
        }
    }
}
