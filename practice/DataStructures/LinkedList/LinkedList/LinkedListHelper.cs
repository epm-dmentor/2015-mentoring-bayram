namespace Epam.NetMentoring.DataStructures
{
    public partial class LinkedList
    {

        internal partial class Node
        {
            public Node Next { get; set; }
            public object Data { get; set; }

            public Node(object value)
            {
                Next = null;
                Data = value;
            }    
        }
        

    }
}
