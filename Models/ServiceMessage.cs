namespace Rabis.Api.Models
{
    public class ServiceMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public MessagePriority MessagePriority { get; set; }
    }
}
