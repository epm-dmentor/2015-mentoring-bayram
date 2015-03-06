using System.Collections;

namespace Epam.NetMentoring.DataStructures
{
    public interface ILinkedList:IEnumerable
    {
        int Count { get; }

        /// <summary>
        /// Inserts an element to end of list
        /// </summary>
        /// <param name="content"></param>
        void Add(object content);

        /// <summary>
        /// Insert element at given position
        /// </summary>
        /// <param name="content"></param>
        /// <param name="position"></param>
        void InsertAt(object content, int position);
        /// <summary>
        /// Returns node data at given position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        object ElementAt(int position);

        bool RemoveAt(int position);
    }
}
