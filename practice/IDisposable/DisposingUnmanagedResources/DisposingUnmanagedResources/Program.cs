using System;

namespace Unmanaged
{
    class Program
    {
        public static void Main()
        {
            using (var console = new ApplicationConsole())
            {
                for (var i = 0; i < 100; i++)
                {
                    console.WriteLine("Line number: {0}", i);
                    console.WriteToFile("Line number: {0} \r\n", i);
                }
            }
            //console.Dispose();
            //console.Dispose();
            Console.ReadKey();
        }

    }
}
