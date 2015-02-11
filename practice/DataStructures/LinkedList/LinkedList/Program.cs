using System;
using System.Drawing;

namespace Epam.NetMentoring.DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var el1 = new Point(1, 2);
            var el2 = new Point(2, 4);
            var el3 = new Point(2, 6);

            var linkedList = new LinkedList();
            linkedList.Add(el1);
            linkedList.Add(el2);
            linkedList.Add(el3);
            linkedList.InsertAt(123,0);
           // linkedList.RemoveAt(3);

            var a = linkedList.ElementAt(2);

            Console.ReadKey();
        }
    }
}
