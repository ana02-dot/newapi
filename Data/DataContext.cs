using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                HasMany(u => u.Posts)
                .WithOne(p => p.User);
            modelBuilder.Entity<User>().
                HasMany(u => u.Comments).
                WithOne(c => c.User);
            modelBuilder.Entity<Post>().
                HasMany(p => p.Comments).
                WithOne(c => c.Post);

        }

    }
}
