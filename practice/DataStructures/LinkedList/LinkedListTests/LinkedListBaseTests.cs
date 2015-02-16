using Epam.NetMentoring.DataStructures;
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

            Assert.That(expectedcount,Is.EqualTo(linkedList.Count));


        }

        [Test]
        public void CheckIfElementsInsertsIntoTheEnd()
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

            var actualElement = (Point)linkedList.ElementAt(3);
            Assert.That(actualElement, Is.EqualTo(fourth));
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
        public void CheckIfHeadHasNothangedAfterAddingNewItems()
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

            var actualElement = (Point)linkedList.ElementAt(0);
            Assert.That(actualElement, Is.EqualTo(first));
        }

        [Test]
        public void InsertAtCanInsertInTheHead()
        {
            var linkedList = GetTestList();
            var newPoint = new Point(200, 200);
            linkedList.InsertAt(newPoint, 0);

            var actualElement = (Point)linkedList.ElementAt(0);
            Assert.That(actualElement, Is.EqualTo(newPoint));
        }

        [Test]
        public void InsertAtCanInsertInTheTail()
        {
            var linkedList = GetTestList();
            var newPoint = new Point(200, 200);
            var newPosition = linkedList.Count;
            Assert.DoesNotThrow(() => linkedList.InsertAt(newPoint, newPosition), String.Format("Should be able to insert into position {0}", newPosition));

            var actualElement = (Point)linkedList.ElementAt(newPosition);
            Assert.That(actualElement, Is.EqualTo(newPoint));
        }

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

    }
}
