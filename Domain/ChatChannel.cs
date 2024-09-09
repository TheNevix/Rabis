using System.ComponentModel.DataAnnotations.Schema;

namespace Rabis.Api.Domain
{
    public class ChatChannel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Server")]
        public Guid ServerId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public Server Server { get; set; }
    }
}
