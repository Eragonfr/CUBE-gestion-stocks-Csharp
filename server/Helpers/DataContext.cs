using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Entities;

namespace server.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UsePostgresql(Configuration.GetConnectionString("serverDatabase"));
        }

        public DbSet<User> Users { get; set; }
    }
}
