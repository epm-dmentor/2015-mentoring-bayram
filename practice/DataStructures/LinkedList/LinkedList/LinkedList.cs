using System;
using System.Collections;

namespace Epam.NetMentoring.DataStructures
{
    public partial class LinkedList : ILinkedList
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

        Node PreviousNode(int position)
        {
            var current = _head;
            if (position < 0 || position > _count)
                throw new ArgumentOutOfRangeException("position",
                          String.Format("Requested positions: {0}, list size = {1}", position, _count));
            
            for (var i = 1; i < position && current.Next != null; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public void InsertAt(object content, int position)
        {
            if (position < 0 || position > _count) 
             throw new ArgumentOutOfRangeException("position",
                       String.Format("Requested positions: {0}, list size = {1}",position,_count));
            
            var node = new Node(content);
            if (position == 0 && _head == null || position == _count)
            {
                Add(content);
            }
            else if (position == 0)
            {
                var temp = _head;
                _head = node;
                _head.Next = temp;
                _count++;
            }
            else
            {
                var current = PreviousNode(position);
                node.Next = current.Next;
                current.Next = node;
                _count++;
            }
        }

        public object ElementAt(int position)
        {
            if (position < 0 || position >= _count) throw new ArgumentOutOfRangeException("position",
                       String.Format("Requested positions: {0}, list size = {1}", position, _count)); 
            if (position == 0) return _head.Data;
            if (position == _count - 1) return _tail.Data;
            
            var current = PreviousNode(position);
            return current.Next.Data;
        }

        public bool RemoveAt(int position)
        {
            if (position == 0 && _head == null) throw new NullReferenceException("Cannot remove non existing element");
            
            if (position < 0 || position >= Count) throw new ArgumentOutOfRangeException("position",
                       String.Format("Requested positions: {0}, list size = {1}", position, _count)); 

            if (position == 0)
            {
                _head = _head.Next;
            }
            else if (position == _count - 1)
            {
                var prevtail = PreviousNode(position);
                _tail = prevtail;
                _tail.Next = null;
    
            }
            else
            {
                var current = PreviousNode(position);
                current.Next = current.Next.Next;
            }
            
            _count--;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}
