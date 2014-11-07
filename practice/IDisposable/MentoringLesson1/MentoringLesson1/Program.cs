using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringLesson1
{
    class ExtendedFileWriter:FileStream
    {
        public ExtendedFileWriter(string FileName,FileMode mode):base(FileName,mode)
        {
           
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }


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
