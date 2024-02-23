using BenchmarkDataAccessTools.Entity;
using Microsoft.EntityFrameworkCore;

namespace BenchmarkDataAccessTools.EFCore
{
    public class EFContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary key
            modelBuilder.Entity<AppUser>()
                .HasKey(e => e.UserId);
        }
    }
}
