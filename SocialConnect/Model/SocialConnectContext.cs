


using Microsoft.EntityFrameworkCore;

namespace SocialConnect.Model
{
    public class SocialConnectContext : DbContext
    {
        public SocialConnectContext(DbContextOptions<SocialConnectContext> options) : base(options)
        {

        }

        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<User> Users { get; set;  }

    }
}
