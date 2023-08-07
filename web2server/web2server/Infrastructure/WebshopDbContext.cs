using Microsoft.EntityFrameworkCore;
using web2server.Models;

namespace web2server.Infrastructure
{
    public class WebshopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }

        public WebshopDbContext(DbContextOptions options) : base(options)
        {
        }

        // nad celim asemblijem konfigurise modele
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebshopDbContext).Assembly);
        }
    }
}
