using System.ComponentModel.DataAnnotations.Schema;

namespace Rabis.Api.Domain
{
    public class UserServer
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Server")]
        public Guid ServerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public User User { get; set; } = new User();
        public Server Server { get; set; } = new Server();
    }
}
