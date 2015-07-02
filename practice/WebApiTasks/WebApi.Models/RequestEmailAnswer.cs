namespace WebApi.Models
{
    public class RequestEmailAnswer
    {
        public long MailId { get; set; }
        public long RequestId { get; set; }
        public long MailTemplateId { get; set; }
    }
}
