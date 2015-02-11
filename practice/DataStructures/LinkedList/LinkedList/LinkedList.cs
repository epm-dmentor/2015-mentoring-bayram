using System;

namespace Epam.NetMentoring.DataStructures
{
    public class LinkedList : ILinkedList
    {
        class Node
        {
            public Node Next { get; set; }
            public object Data { get; private set; }

            public Node(object value)
            {
                Next = null;
                Data = value;
            }

        }

        private Node _head;
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
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = temp;

            }
            _count++;
        }

        public void InsertAt(object content, int position)
        {
            if (position < 0 || position >= _count) throw new Exception("Out of bound Exception");
            var node = new Node(content);

            if (position == 0)
            {
                var temp = _head;
                _head = node;
                _head.Next = temp;

            }
            else
            {
                var current = _head;
                for (var i = 1; i < position && current.Next != null; i++)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;
                _count++;
            }
        }

        public object ElementAt(int position)
        {
            if (position < 0 || position >= _count) throw new ArgumentOutOfRangeException();
            if (position == 0) return _head.Data;

            var current = _head.Next;

            for (var i = 1; i < position; i++)
            {
                if (current.Next == null) return null;
                current = current.Next;
            }

            return current.Data;
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

            var current = _head;
            for (var i = 1; i < position; i++)
            {
                if (current.Next == null) return false;
                current = current.Next;
            }
            current.Next = current.Next.Next;
            _count--;
            return true;
        }
    }
}
