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


           // var newPoint = new Point(200, 200);
            var newPoint2 = new Point(201, 201);
           // var newPosition = linkedList.Count;
            linkedList.Add(newPoint2);
 
            
            
            
            linkedList.InsertAt(first,3);

            foreach (var s in linkedList)
            {
               var n = (Node)s;
               Console.WriteLine(n.Data);
            }
            
            Console.ReadKey();
        }
    }
}
