using System.Collections.Generic;

namespace Epam.NetMentoring.Adapter
{
    public interface IContainer
    {
        IEnumerable<object> Items { get; }
        int Count { get; }
    }
}
