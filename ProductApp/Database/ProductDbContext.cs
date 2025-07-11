using Microsoft.EntityFrameworkCore;
using ProductApp.Models;

namespace ProductApp.Database
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(){}
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True;Trust Server Certificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.ProName)
                    .IsRequired()
                    .HasMaxLength(20);    //defines ProName's MaxLength as 20 characters no more than that

                entity.Property(p => p.Currency)
                    .HasConversion<string>();

                entity.Property(p => p.Quantity)
                    .HasDefaultValue(1);
            });
        }
        public DbSet<Product> Products { get; set; }
    }
}
