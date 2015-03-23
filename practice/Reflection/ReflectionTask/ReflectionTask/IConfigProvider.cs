using System.Collections.Generic;

namespace NetMentoring.Epam.ReflectionTask
{
    interface IConfigProvider
    {
        T GetSettings<T>() where T : new();
        IEnumerable<string> GetConfigList(string location);
        IEnumerable<ConfigEntity> GetParsedList(IEnumerable<string> list);
    }
}
