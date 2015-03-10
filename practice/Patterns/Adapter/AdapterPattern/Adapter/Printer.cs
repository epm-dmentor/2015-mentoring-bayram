using System;

namespace Epam.NetMentoring.Adapter
{
    public class Printer
    {
        public void Print(IContainer container)
        {
            foreach (var item in container.Items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
