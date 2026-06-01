using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "alawoddin"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "developer"
                }
            );
        }
    }
}
