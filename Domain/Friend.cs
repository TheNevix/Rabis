using System.ComponentModel.DataAnnotations.Schema;

namespace Rabis.Api.Domain
{
    public class Friend
    {
        public Guid Id { get; set; }
        [ForeignKey("User1")]
        public Guid UserId1 { get; set; }
        [ForeignKey("User2")]
        public Guid UserId2 { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
