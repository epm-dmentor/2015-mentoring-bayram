using System.Collections.Generic;
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

            //IT: Changed linkedList.Count to linkedList.Count-1, because last element should be Count-1.
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
