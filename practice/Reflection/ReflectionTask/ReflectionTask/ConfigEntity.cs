using System.Collections.Generic;

namespace NetMentoring.Epam.ReflectionTask
{
    public class ConfigEntity
    {
        public string Name { get; set; }
        public string NameSpace { get; set; }
        public Dictionary<string,string> Properties { get; set; } 
    }
}
