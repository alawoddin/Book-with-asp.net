using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "alawoddin",
                    DisplayOrder = 1,
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "developer",
                    DisplayOrder = 2,
                }
            );
        }
    }
}
