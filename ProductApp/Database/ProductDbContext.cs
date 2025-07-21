using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.ProName)
                   .IsRequired()
                   .HasMaxLength(20);    //defines ProName's MaxLength as 20 characters no more than that

                builder.Property(p => p.Currency)
                    .HasConversion<string>();

                builder.Property(p => p.Quantity)
                    .HasDefaultValue(1);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        
        public DbSet<Product> Products { get; set; }
    }
    
}
