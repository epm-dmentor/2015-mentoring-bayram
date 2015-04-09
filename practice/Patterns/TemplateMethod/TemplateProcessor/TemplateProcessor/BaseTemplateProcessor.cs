using System;
using System.Linq;

namespace Epam.NetMentoring.TemplateProcessor
{
    public class BaseTemplateProcessor
    {
        public void ProcessTemplate(Template template,string username)
        {
            var user = template.Users.FirstOrDefault(x => x.Name.Equals(username));
            CheckAccessTo(template,user);
            CheckEmailsIn(template);
            CheckForCorporateEmail(template);
            CheckEmailContent(template);
            CheckVars(template);
            Save(template);
        }

        protected virtual void Save(Template template)
        {
            Console.WriteLine("Saved Template '{0}'",template.Name);
        }

        protected virtual void CheckVars(Template template)
        {
            Console.WriteLine("BaseTemplate variables check");
        }

        protected virtual void CheckEmailContent(Template template)
        {

            Console.WriteLine("Checked Email Content '{0}'",template.Name);
        }

        protected virtual void CheckForCorporateEmail(Template template)
        {
            Console.WriteLine("Checked for Corporate Emails '{0}'",template.Name);
        }

        protected virtual void CheckEmailsIn(Template template)
        {
            Console.WriteLine("Checked Emails for '{0}'",template.Name);
        }

        protected virtual void CheckAccessTo(Template template, User user)
        {
            if (template.Users.Contains(user))
            {
               Console.WriteLine("User '{0}' has access to '{1}'",user.Name,template.Name);    
            }
            else
            {
                Console.WriteLine("User '{0}' has no access to '{1}'",user.Name,template.Name);
            }
            
        }
    }
}
