using System;
using System.Drawing;
using Epam.NetMentoring.DataStructures;
using NUnit.Framework;

namespace LinkedListTests
{

    /// <summary>
    /// RemoveAt Method Tests
    /// </summary>
    [TestFixture]
    public partial class LinkedListBaseTests
    {
        [Test]
        public void RemovingTheLastItem()
        {
            var elementForRemove = 3;
            var points = GetPoints(4);
            var linkedList = FormLinkedList(points);

            linkedList.RemoveAt(elementForRemove);
            points.RemoveAt(elementForRemove);
            var expectedElementCountsAfterRemoving = points.Count;
            Assert.That(linkedList.Count, Is.EqualTo(expectedElementCountsAfterRemoving));

            for (var i = 0; i < linkedList.Count; i++)
            {
                Assert.That(linkedList.ElementAt(i), Is.EqualTo(points[i]), String.Format("Element number: {0}", i));
            }
        }

        [Test]
        public void RemovingInTheMiddleShouldWorkProperly()
        {
            var el1 = new Point(1, 2);
            var el2 = new Point(2, 4);
            var el3 = new Point(3, 5);

            var linkedList = new LinkedList();
            linkedList.Add(el1);
            linkedList.Add(el2);
            linkedList.Add(el3);
            linkedList.RemoveAt(1);

            var actualElement = (Point)linkedList.ElementAt(0);
            Assert.That(actualElement, Is.EqualTo(el1));

            actualElement = (Point)linkedList.ElementAt(1);
            Assert.That(actualElement, Is.EqualTo(el3));

            const int expectedCount = 2;
            Assert.That(linkedList.Count, Is.EqualTo(expectedCount));
        }


    }
}
