using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SocialConnect.Model
{
    public class SocialConnectContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection DbConnection { get; }
        public SocialConnectContext(DbContextOptions<SocialConnectContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            DbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection.ToString());
            }
        }

        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<MemberComment> UserComments { get; set; }
        public DbSet<Member> Members { get; set;  }
        public DbSet<ShareEntity> Shares { get; set; }
    }
}
