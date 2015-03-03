using System;
using System.Collections.Generic;
using System.Drawing;
using Epam.NetMentoring.DataStructures;
using NUnit.Framework;

namespace LinkedListTests
{

    /// <summary>
    /// ElementAt, Count, Enumeration Tests
    /// </summary>
    [TestFixture]
    public partial class LinkedListBaseTests
    {
        [Test]
        public void CountTest()
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
            const int expectedcount = 4;

            Assert.That(expectedcount, Is.EqualTo(linkedList.Count));


        }



        [Test]
        public void CheckElementAtWorksCorrectIntheMiddleOfTheList()
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

            var actualElement = (Point)linkedList.ElementAt(1);
            Assert.That(actualElement, Is.EqualTo(secound));
        }

        [Test]
        public void EnumerationShouldReturnsAllItems()
        {
            var points = new List<Point>(4);
            points.Add(new Point(1, 2));
            points.Add(new Point(1, 3));
            points.Add(new Point(1, 4));
            points.Add(new Point(1, 6));

            var linkedList = new LinkedList();
            linkedList.Add(points[0]);
            linkedList.Add(points[1]);
            linkedList.Add(points[2]);
            linkedList.Add(points[3]);

            var i = 0;
            foreach (var point in linkedList)
            {
                Assert.That(point, Is.EqualTo(points[i]));
                i++;
            }
        }

        [Test]
        public void EnumerationOfEmptyListShouldNotGenerateException()
        {
            var linkedList = new LinkedList();

            var i = 0;
            foreach (var point in linkedList)
            {
                Console.Write(point);
                i++;
            }

            Assert.That(linkedList.Count, Is.EqualTo(0));
        }


    }
}
