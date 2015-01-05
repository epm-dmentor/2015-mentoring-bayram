using System;

namespace CalculatorDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var result =
                new Add(new Multiply(new Const(12), new Const(3)),
                    new Plus(new Const(2), new Divide(
                             new Const(12), new Const(3))))
                             .GetResult();
=======

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
>>>>>>> 27c82def8acb8fc84260fec7506fe2994e1bda83
            
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
