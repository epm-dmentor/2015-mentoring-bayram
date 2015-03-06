using System;
using System.Drawing;
using Epam.NetMentoring.DataStructures;
using NUnit.Framework;

namespace LinkedListTests
{
    [TestFixture]
    public partial class LinkedListBaseTests
    {
        #region CountMethodTests

        [Test]
        public void EmtpyListShouldReturnZeroCount()
        {
            var list  = new LinkedList();
            Assert.AreEqual(0,list.Count);
        }

        [Test]
        public void CheckElementCount()
        {
            var list = GetTestList();
            Assert.AreEqual(4,list.Count);
        }

        [Test]
        public void CheckCountWithDifferentAddMethods()
        {
            var elementHead = new Point(0, 12);
            var elementMidd = new Point(45, 45);
            var elementTail = new Point(74, 45);
            var list = GetTestList();
            list.InsertAt(elementHead,0);
            Assert.AreEqual(5,list.Count);
            list.InsertAt(elementMidd,3);
            Assert.AreEqual(6,list.Count);
            list.InsertAt(elementTail,5);
            Assert.AreEqual(7,list.Count);
        }

        [Test]
        public void CheckCountWithRemoveMethod()
        {
            var element = new Point(2, 22);
            var list = GetTestList();
            list.RemoveAt(0);
            Assert.AreEqual(3,list.Count);
            list.RemoveAt(1);
            Assert.AreEqual(2,list.Count);
            list.Add(element);
            list.RemoveAt(1);
            Assert.AreEqual(2,list.Count);
        }
        #endregion CountMethodTests

        #region AddMethodTests

        [Test]
        public void AddOneElement()
        {
            var element = new Point(1, 1);
            var list = new LinkedList {element};
            Assert.That(element,Is.EqualTo(list.ElementAt(0)));
            Assert.AreEqual(1,list.Count);
        }

        [Test]
        public void CheckIfAddedElementIsLast()
        {
            var first = new Point(1, 1);
            var second = new Point(2, 2);
            var third = new Point(3, 3);
            var list = new LinkedList {first, second};
            list.Add(third);
            Assert.That(third,Is.EqualTo(list.ElementAt(2)));
            Assert.AreEqual(3,list.Count);

        }

        [Test]
        public void AddMethodWithInsertAt()
        {
            var first = new Point(1, 1);
            var second = new Point(2, 2);
            var third = new Point(3, 3);
            var forth = new Point(4, 4);
            var list = new LinkedList();
            list.InsertAt(first,0);
            list.InsertAt(second,1);
            list.InsertAt(third,2);
            list.Add(forth);
            Assert.That(forth,Is.EqualTo(list.ElementAt(3)));
            Assert.AreEqual(4,list.Count);

        }

        [Test]
        public void AddMethodWithRemoveAt()
        {
            var element = new Point(1, 1);
            var list = GetTestList();
            list.RemoveAt(2);
            list.Add(element);
            Assert.That(element,Is.EqualTo(list.ElementAt(3)));
            Assert.AreEqual(4,list.Count);
        }
        #endregion AddMethodTestsj


        #region InsertAtTests

        [Test]
        public void InsertAtEmptyList()
        {
            var element = new Point(1, 1);
            var list = new LinkedList();
            list.InsertAt(element,0);
            Assert.That(element, Is.EqualTo(list.ElementAt(0)));
            Assert.AreEqual(1,list.Count);

        }

        [Test]
        public void InsertAtOutOfRange()
        {
            var element = new Point(1, 1);
            var list = new LinkedList();
            Assert.Throws<ArgumentOutOfRangeException>(()=>list.InsertAt(element,-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAt(element, 1));
            
        }

        [Test]
        public void InsertAtAfterAddMethod()
        {
            var element = new Point(3, 12);
            var list = GetTestList();
            list.InsertAt(element,2);
            Assert.That(element,Is.EqualTo(list.ElementAt(2)));
        }

        [Test]
        public void InsertAtWithElementAt()
        {
            var first = new Point(1, 1);
            var second = new Point(2, 2);
            var third = new Point(3, 3);
            var forth = new Point(4, 4);
            var list = new LinkedList();
            list.InsertAt(first,0);
            list.InsertAt(second,1);
            list.InsertAt(third,2);
            list.InsertAt(forth,3);
            var i = 0;
            foreach (var element in list)
            {
                Assert.That(element,Is.EqualTo(list.ElementAt(i)));
                i++;
            }
        }

        [Test]
        public void InsertAtWithRemove()
        {
            var element = new Point(4, 3);
            var list = GetTestList();
            list.RemoveAt(3);
            list.InsertAt(element,3);
            Assert.That(element,Is.EqualTo(list.ElementAt(3)));
        }
        #endregion InsertAtTests

        #region ElementAtTests

        [Test]
        public void ElementAtOutofRange()
        {
            var list = new LinkedList();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ElementAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ElementAt(1));
            
        }

        [Test]
        public void ElementAtAfterAdding()
        {
            var list = GetTestList();
            var i = 0;
            foreach (var element in list)
            {
                Assert.That(element,Is.EqualTo(list.ElementAt(i)));
                i++;
            }
        }

        [Test]
        public void ElementAtWrongPosition()
        {
            var list = GetTestList();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.ElementAt(4));
        }
        #endregion ElementAtTests
        
        #region RemoveAtTests

        [Test]
        public void RemoveAtOutofRange()
        {
            var list = new LinkedList();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
            Assert.Throws<NullReferenceException>(() => list.RemoveAt(0));
        }

        [Test]
        public void RemoveAtPositions()
        {
            var list = GetTestList();
            list.RemoveAt(0);
            Assert.AreEqual(3,list.Count);
            list.RemoveAt(1);
            Assert.AreEqual(2,list.Count);
            list.RemoveAt(0);
            Assert.AreEqual(1,list.Count);
        }
        [Test]
        public void RemoveAtZeroIndex()
        {
            var element = new Point(1, 1);
            var list = new LinkedList {element};
            list.RemoveAt(0);
            Assert.AreEqual(0,list.Count);
        }
        #endregion RemoveAtTests
    }
}
