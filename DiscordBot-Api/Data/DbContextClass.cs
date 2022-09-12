using DiscordBot_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DiscordBot_Api.Data
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasNoKey();
        }

        public DbSet<Message> Messages { get; set; }
    }
}
