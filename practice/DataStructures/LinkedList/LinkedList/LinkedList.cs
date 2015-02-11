using System;

namespace Epam.NetMentoring.DataStructures
{
    public class LinkedList:ILinkedList
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
            if (position<0 || position>_count) throw new Exception("Out of bound Exception");
            
            var temp = new Node(content);
            var current = _head;

            for (var i = 1; i < position && current.Next!=null; i++)
            {
                current = current.Next;
            }

            temp.Next = current.Next;
            current.Next = temp;
            _count++;
        }

        public object ElementAt(int position)
        {
            if (position < 0 || position>_count) throw new ArgumentOutOfRangeException();
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
            if (position < 1 || position > Count) return false;

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
