using System;
using System.Collections.Generic;
using System.Drawing;

namespace Epam.NetMentoring.DataStructures
{
    class Program
    {
        private ILinkedList GetTestList()
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

            return linkedList;
        }

        private static LinkedList FormLinkedList(List<Point> points)
        {
            var linkedList = new LinkedList();
            foreach (var point in points)
            {
                linkedList.Add(point);
            }

            return linkedList;
        }

        private static List<Point> GetPoints(int count)
        {
            var points = new List<Point>(count);

            for (var i = 0; i < count; i++)
            {
                points.Add(new Point(-i, i));
            }

            return points;
        }
        static void Main(string[] args)
        {

            var elementForRemove = 3;
            var points = GetPoints(4);
            var linkedList = FormLinkedList(points);
            foreach (var s in linkedList)
            {
                Console.WriteLine(s);
            }

            linkedList.RemoveAt(elementForRemove);
            points.RemoveAt(elementForRemove);
            var expectedElementCountsAfterRemoving = points.Count;

            for (var i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList.ElementAt(i)+"------"+points[i]);
                
            }
          
            Console.ReadKey();
        }
    }
}
