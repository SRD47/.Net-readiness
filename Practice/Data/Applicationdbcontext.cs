using Microsoft.EntityFrameworkCore;
using Practice.Models.Entities;

namespace Practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ID);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(p => p.Category)
                    .IsRequired();

                entity.Property(p => p.Class)
                    .IsRequired();

                entity.Property(p => p.Quantity)
                    .IsRequired();

                entity.Property(p => p.Price)
                    .IsRequired();

                // Store enum as string in DB for readability
                entity.Property(p => p.Currency)
                    .IsRequired()
                    .HasConversion<string>();
            });
        }
    }
}
