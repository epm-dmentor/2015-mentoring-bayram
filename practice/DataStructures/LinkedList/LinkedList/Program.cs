using System;
using System.Drawing;

namespace Epam.NetMentoring.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            var point = new Point() {X=1,Y=2};
            list.Add(point);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.InsertAt(point,-1);
            var node = list.ElementAt(0);
            int size = list.Count;
            list.InsertAt(5, 2);
            list.RemoveAt(2);
            
            Console.ReadKey();
        }
    }
}
