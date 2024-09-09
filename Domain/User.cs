namespace Rabis.Api.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset LastLogin { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public ICollection<Friend> Friends { get; set; } = new List<Friend>();
        public ICollection<UserServer> UserServers { get; set; } = new List<UserServer>();
    }
}
