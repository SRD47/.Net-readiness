using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductDesktop.Entities;

namespace ProductDesktop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(){}
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProductAppUsers;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        public class UserConfiguration : IEntityTypeConfiguration<AppUsers>
        {
            public void Configure(EntityTypeBuilder<AppUsers> entity)
            {
                entity.HasKey(k => k.Id);

                entity.Property(n => n.Name)
                    .IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired();

                entity.Property(e => e.Roles)
                    .HasConversion<string>();

                //entity.HasMany(u => u.P)

                entity.HasData(new AppUsers {Id = 1, Name = "Admin",Username="Admin" ,Password = "admin", Roles = Roles.Admin});
            }
        }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> e)
            {
                e.HasKey(k => k.Id);

                e.Property(n => n.Name) .IsRequired();

                e.Property(c => c.Category).HasConversion<String>();

                e.Property(c => c.Stock).IsRequired();

                e.Property(c => c.Currency).HasConversion<String>();

                e.Property(p => p.Price).IsRequired();

                e.HasData(new Product { Id = 1, Name = "Laptop", Category = Category.ElectronicsAndAppliances, Stock = 10, Currency = Currency.USD, Price = 999.99 },
                            new Product { Id = 2, Name = "Smartphone", Category = Category.ElectronicsAndAppliances, Stock = 25, Currency = Currency.USD, Price = 599.49 },
                            new Product { Id = 3, Name = "Desk Chair", Category = Category.HomeAndLiving, Stock = 0, Currency = Currency.USD, Price = 149.99 },
                            new Product { Id = 4, Name = "Monitor", Category = Category.ElectronicsAndAppliances, Stock = 15, Currency = Currency.INR, Price = 199.99 },
                            new Product { Id = 5, Name = "Pen", Category = Category.HomeAndLiving, Stock = 100, Currency = Currency.NRS, Price = 0.99 });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
       public DbSet<AppUsers> AppUsers { get; set;} 
       public DbSet<Product> Products { get; set;}

    }
}
