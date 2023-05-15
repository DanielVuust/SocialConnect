using Microsoft.EntityFrameworkCore;

namespace SocialConnect.Model
{
    public class SocialConnectContext : DbContext
    {
        public SocialConnectContext(DbContextOptions<SocialConnectContext> options) : base(options)
        {

        }

        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<MemberComment> UserComments { get; set; }
        public DbSet<Member> Members { get; set;  }

    }
}
