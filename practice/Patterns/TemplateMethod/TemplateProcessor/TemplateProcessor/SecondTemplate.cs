using System;

namespace Epam.NetMentoring.TemplateProcessor
{
    public class SecondTemplate:BaseTemplateProcessor
    {
        protected override void CheckVars(Template template)
        {
            Console.WriteLine("Checked variables for Template 2 {0}",template.Name);
        }
    }
}
