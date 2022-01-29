using AdServiceCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AdServiceData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<Ad> Ads { get; set; }
    }
}
