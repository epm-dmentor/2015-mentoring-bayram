using System;
using System.Collections;

namespace Epam.NetMentoring.DataStructures
{
    public class LinkedList : ILinkedList,IEnumerable    
    {
        private Node _head;
        private Node _tail;
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public void Add(object content)
        {
            var temp = new Node(content);

            if (_head == null)
            {
                _head = temp;
                _tail = temp;
                _count++;
            }
            else
            {
                var current = _tail;
                current.Next = temp;
                _tail = current.Next;
                _count++;
            }
        }

        Node NodeAt(int position)
        {
            var current = _head;
            for (var i = 1; i < position && current.Next != null; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public void InsertAt(object content, int position)
        {
            if (position < 0 || position > _count) throw new Exception("Out of bound Exception");
            var node = new Node(content);

            if (position == 0 && _head == null)
            {
                Add(content);
                
            }
            else if (position == _count)
            {
                var current = _tail;
                current.Next = node;
                _tail = current.Next;
                _count++;
            }
            else if (position == 0)
            {
                var temp = _head;
                _head = node;
                _head.Next = temp;
                _count++;
            }
            else if (position == _count-1)
            {
                var current = NodeAt(position);
                node.Next = current.Next;
                current.Next = node;
                _tail = current.Next.Next;
                _count++;
            }
            else
            {
                var current = NodeAt(position);
                node.Next = current.Next;
                current.Next = node;
                _count++;
            }
        }

        public object ElementAt(int position)
        {
            if (position < 0 || position >= _count) throw new ArgumentOutOfRangeException();
            if (position == 0) return _head.Data;
            if (position == _count-1) return _tail.Data;
            var current = NodeAt(position);
            return current.Next.Data;
        }

        public bool RemoveAt(int position)
        {
            if (position < 0 || position >= Count) return false;
            if (position == 0)
            {
                _head = _head.Next;
                _count--;
                return true;
            }
            if (position == _count)
            {
                var prevtail = NodeAt(position - 1);
                _tail = prevtail;
                _count--;
            }
            var current = NodeAt(position);
            current.Next = current.Next.Next;
            _count--;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            var current = _head;
            for (var i = 1; i < Count && current.Next != null; i++)
            {
                yield return current = current.Next;
            }
            
        }
    }
}
