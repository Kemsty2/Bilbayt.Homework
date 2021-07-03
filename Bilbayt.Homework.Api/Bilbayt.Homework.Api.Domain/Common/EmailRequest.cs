namespace Bilbayt.Homework.Api.Domain.Common
{
    public class EmailRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string EmailTo { get; set; }
        public string EmailToName { get; set; }
    }
}