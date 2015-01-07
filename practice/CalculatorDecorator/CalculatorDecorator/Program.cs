using System;

namespace Epam.NetMentoring.Calculator
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
            Console.ReadKey();
        }
    }
}
