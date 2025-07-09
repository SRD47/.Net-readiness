using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ProductApp.Database
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext()
        {    
        }
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
                entity.HasKey(e =>  e.Id);

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(20);    //defines ProName's MaxLength as 20 characters no more than that

                entity.Property(e => e.Currency)
                    .HasConversion<string>();

            });
        }
        public DbSet<Product> Products { get; set; }
    }
}
