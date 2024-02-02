using Homework1.API.Models.Categories;
using Homework1.API.Models.Definitions;
using Homework1.API.Models.ProductFeatures;
using Homework1.API.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Homework1.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductDefinition> ProductDefinitions { get; set; }

        //ef core'un default davranışlarını değiştirebiliriz :
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
