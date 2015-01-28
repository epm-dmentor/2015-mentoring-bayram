namespace Epam.NetMentoring.LinkedList
{
    public class LinkedList
    {
        public class Node
        {
            public object Content;
            public Node Next;
        }

        private int _size;
        private Node _head;
        private Node _current;

        public LinkedList()
        {
            _size = 0;
            _head = null;
        }

        public int Count
        {
            get { return _size; }
        }

        public void Add(object content)
        {
            _size++;

            var node = new Node()
            {
                Content = content
            };

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _current.Next = node;
            }
            _current = node;
        }

        public void InsertAt(object content, int position)
        {
            _size++;

            var node = new Node()
            {
                Content = content
            };

            if (position == 1)
            {
                var tempNode = _head;
                _head = node;
                _head.Next = tempNode;
            }
            int count = 0;
            if (position > 1 && position <= _size)
            {
                var tempNode = _head;
                Node lastNode = null;
                while (tempNode != null)
                {
                    if (count == position - 1)
                    {
                        node.Next = tempNode;
                        lastNode.Next = node;

                    }
                    count++;
                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }

        }

        public Node ElementAt(int position)
        {
            var tempNode = _head;
            Node resultNode = null;
            int count = 0;

            while (tempNode != null)
            {
                if (count == position - 1)
                {
                    resultNode = tempNode;
                    break;
                }
                count++;
                tempNode = tempNode.Next;
            }

            return resultNode;
        }

        public bool RemoveAt(int position)
        {
            if (position == 1)
            {
                _head = null;
                _current = null;
                return true;
            }
            int count = 0;
            if (position > 1 && position <= _size)
            {
                var tempNode = _head;
                Node lastNode = null;
                while (tempNode != null)
                {
                    if (count == position - 1)
                    {
                        lastNode.Next = tempNode.Next;
                        return true;
                    }
                    count++;
                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }
            return false;
        }
    }
}
