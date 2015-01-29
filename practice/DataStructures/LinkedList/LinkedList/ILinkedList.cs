using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.LinkedList
{
    public interface ILinkedList
    {
        int Count { get; }
        void Add(object content);
        void InsertAt(object content, int position);
        object ElementAt(int position);
        bool RemoveAt(int position);
    }
}
