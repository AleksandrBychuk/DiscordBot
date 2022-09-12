using DiscordBot_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot_Identity.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
