using System;
using System.Drawing;
using Epam.NetMentoring.DataStructures;
using NUnit.Framework;

namespace LinkedListTests
{

    /// <summary>
    /// InsertAt Method and Add Method Tests
    /// </summary>
    [TestFixture]
    public partial class LinkedListBaseTests
    {
        [Test]
        public void ThrowExceptionInCaseInsertingToIncorrectPosition()
        {
            var linkedList = new LinkedList();
            Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.InsertAt(new Point(1, 2), -1));
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

        [Test]
        public void AddAfterInsertAtMustInsertAtTheEnd()
        {
            var linkedList = GetTestList();
            var newPoint = new Point(200, 200);
            var newPosition = linkedList.Count;
            Assert.DoesNotThrow(() => linkedList.InsertAt(newPoint, newPosition), String.Format("Should be able to insert into position {0}", newPosition));


            var newPoint2 = new Point(201, 201);
            Assert.DoesNotThrow(() => linkedList.Add(newPoint2), String.Format("Should add to the end"));

            var actualElement = (Point)linkedList.ElementAt(linkedList.Count - 1);
            Assert.That(actualElement, Is.EqualTo(newPoint2));
        }        
    }
}
