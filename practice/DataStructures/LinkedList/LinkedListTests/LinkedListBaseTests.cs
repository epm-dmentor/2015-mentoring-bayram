using System.Collections.Generic;
using Epam.NetMentoring.DataStructures;
using NUnit.Framework;
using System.Drawing;

namespace LinkedListTests
{
    [TestFixture]
    public partial class LinkedListBaseTests
    {
        #region Helpers
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
        #endregion Helpers
    }
}
