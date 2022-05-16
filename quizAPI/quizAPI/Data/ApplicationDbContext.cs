using Microsoft.EntityFrameworkCore;
using quizAPI.Models;

namespace quizAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<>
        //}
        public DbSet<Player> Players { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
