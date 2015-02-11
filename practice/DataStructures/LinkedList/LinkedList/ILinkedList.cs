namespace Epam.NetMentoring.DataStructures
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
