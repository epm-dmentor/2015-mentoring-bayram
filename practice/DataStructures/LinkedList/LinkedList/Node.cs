namespace Epam.NetMentoring.DataStructures
{
    public partial class Node
    {
        public Node Next { get; set; }
        public object Data { get; private set; }

        public Node(object value)
        {
            Next = null;
            Data = value;
        }

    }
}
