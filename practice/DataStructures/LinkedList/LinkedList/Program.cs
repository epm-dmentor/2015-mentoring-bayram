using System;
using System.Drawing;

namespace Epam.NetMentoring.DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {

            var first = new Point(1, 2);
            var secound = new Point(1, 3);
            var third = new Point(1, 4);
            var fourth = new Point(1, 6);
            var linkedList = new LinkedList();
            linkedList.Add(first);
            linkedList.Add(secound);
            linkedList.Add(third);
            linkedList.Add(fourth);
            
            var newPoint = new Point(200, 200);
            var newPosition = linkedList.Count;
            linkedList.InsertAt(newPoint, newPosition);
            
            Console.ReadKey();
        }
    }
}
