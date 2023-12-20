using Microsoft.EntityFrameworkCore;

namespace RedisExampleAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "TV",
                    Price = 15000.99m
                },
                new Product
                {
                    Id = 2,
                    Name = "Kalem",
                    Price = 100.99m
                },
                new Product
                {
                    Id = 3,
                    Name = "PC",
                    Price = 24000.98m
                },
                new Product
                {
                    Id = 4,
                    Name = "Çamaşır Makinesi",
                    Price = 5000m
                });
        }
    }
}
