using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringLesson1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var logger = new MemoryStreamLogger())
            {
            
                logger.Log("Test");
                logger.Log("Test2");
               
            }
            
            Console.WriteLine("Finished");
            Console.ReadKey();
            
        }
    }
}
