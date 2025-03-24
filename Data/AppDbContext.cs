using EF10_Other_query_improvements.Models;
using Microsoft.EntityFrameworkCore;

namespace EF10_Other_query_improvements.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsMany(e => e.Attendees);
        }
    }
}

