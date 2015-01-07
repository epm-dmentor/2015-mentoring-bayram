using System;

namespace CalculatorDecorator
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = 
                new Add(
                    new Multiply(
                        new Const(12),
                        new Const(3)), 
                        new Plus(
                            new Const(2),
                            new Divide(
                                new Const(12),
                                new Const(3)))).GetResult();

            
            Console.WriteLine(result);


            var calc = new CalculationService();
            var res1 = calc.Calculate(23, 23);
            var res2 = calc.Calculate(45, 45);
            var res3 = calc.Calculate(23, 23);

            Console.WriteLine("Result one - {0}, Result two {1}, Result from cache {2}",res1,res2,res3);

            Console.ReadKey();
        }
    }
}
