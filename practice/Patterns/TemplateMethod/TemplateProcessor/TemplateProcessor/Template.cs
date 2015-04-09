using System.Collections.Generic;

namespace Epam.NetMentoring.TemplateProcessor
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCorporateEmail { get; set; }
        public IList<Email> Emails { get; set; } 
        public IList<User> Users { get; set; }
    }
}
