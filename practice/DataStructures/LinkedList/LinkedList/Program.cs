using System;

namespace Epam.NetMentoring.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            var node = list.ElementAt(2);
            int size = list.Count;
            list.InsertAt(5, 2);
            list.RemoveAt(2);
            
            Console.ReadKey();
        }
    }
}
