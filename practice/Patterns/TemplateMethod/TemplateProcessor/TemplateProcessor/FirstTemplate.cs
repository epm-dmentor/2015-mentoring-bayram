using System;

namespace Epam.NetMentoring.TemplateProcessor
{
    public class FirstTemplate:BaseTemplateProcessor
    {
        protected override void CheckVars(Template template)
        {
            Console.WriteLine("First Template Check Template Variables {0}",template.Name);
        }

        protected override void CheckAccessTo(Template template, User user)
        {
            base.CheckAccessTo(template, user);

        }

        protected override void CheckEmailsIn(Template template)
        {
            base.CheckEmailsIn(template);
        }
    }
}
