using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizerTutorial
{
    public class MyClass1
    {
        private int _count;
        ~MyClass1()
        {
            
            //MyClass.ClassHolder = this;
            GC.ReRegisterForFinalize(this);
            Console.WriteLine("Zombie {0}", _count);
            _count ++;
            Console.WriteLine(_count);
        }
    }
}
