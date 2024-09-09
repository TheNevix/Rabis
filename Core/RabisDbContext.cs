using Microsoft.EntityFrameworkCore;
using Rabis.Api.Domain;

namespace Rabis.Api.Core
{
    public class RabisDbContext : DbContext
    {
        public RabisDbContext(DbContextOptions<RabisDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserServer> UserServers { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<ChatChannel> ChatChannels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
