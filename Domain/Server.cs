namespace Rabis.Api.Domain
{
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }

        public virtual ICollection<ChatChannel> ChatChannels { get; set; } = new List<ChatChannel>();
        public virtual ICollection<UserServer> UserServers { get; set; } = new List<UserServer>(); 
    }
}
