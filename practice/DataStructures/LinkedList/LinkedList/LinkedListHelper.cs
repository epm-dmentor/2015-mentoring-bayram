namespace Epam.NetMentoring.DataStructures
{
    public partial class LinkedList
    {

        //IT: class Node should not be partial
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
