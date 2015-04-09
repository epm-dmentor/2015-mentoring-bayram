namespace Epam.NetMentoring.TemplateProcessor
{
    public class TemplateFactory
    {
        public BaseTemplateProcessor CreateTemplate(int templateId)
        {
            switch (templateId)
            {
                case 1:
                    return new FirstTemplate();
                case 2:
                    return new SecondTemplate();
                default:
                    return new BaseTemplateProcessor();
            }
        }
    }
}
