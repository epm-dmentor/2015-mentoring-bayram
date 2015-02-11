using Epam.NetMentoring.LinkedList;
using NUnit.Framework;
using System;
using System.Drawing;

namespace LinkedListTests
{
    [TestFixture]
    public class LinkedListBaseTests
    {
        [Test]
        public void ThrowExceptionInCaseInsertingToIncorrectPosition()
        {
            var linkedList = new LinkedList();
            Assert.Throws<Exception>(() => linkedList.InsertAt(new Point(1, 2), -1));
        }

        [Test]
        public void CheckGetElementByIndex()
        {
            var linkedList = new LinkedList();
            var newElement = new Point(1, 2);
            linkedList.Add(newElement);
            var elFromList = linkedList.ElementAt(0);
            Assert.That(elFromList, Is.EqualTo(newElement));
        }

        [Test]
        public void CheckOutOfRangeElementBy()
        {
            var linkedList = new LinkedList();
            var newElement = new Point(1, 2);
            linkedList.Add(newElement);
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.ElementAt(10));
        }

        [Test]
        public void RemovingTheLastItem()
        {            
            var el1 = new Point(1, 2);
            var el2 = new Point(2, 4);

            var linkedList = new LinkedList();
            linkedList.Add(el1);
            linkedList.Add(el2);
            linkedList.RemoveAt(1);

            const int expectedElementCountsAfterRemoving = 1;
            Assert.That(linkedList.Count, Is.EqualTo(expectedElementCountsAfterRemoving));
        }
    }
}
