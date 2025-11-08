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

        public class SupplierConfiguration : IEntityTypeConfiguration<Supplier> { 
        
           public void Configure(EntityTypeBuilder<Supplier> builder) { 
            
                builder.Property(e => e.SupplierId).HasDefaultValueSql("NEWID()");

                builder.Property(p =>  p.SupplierName).IsRequired().HasMaxLength(100);

                builder.Property(e => e.ContactPerson).IsRequired().HasMaxLength(50);

                builder.Property(k => k.Category).HasConversion<String>().IsRequired();   

                builder.Property(e => e.Email).IsRequired();

                builder.HasData(new Supplier { SupplierId = new Guid("11111111-1111-1111-1111-111111111111"), SupplierName = "ABC Traders", ContactPerson = "John Doe", Category = Category.ElectronicsAndAppliances, Description = "Electronic gadgets and accessories", PhoneNumber = "9876543210", Email = "abc@traders.com" },
                                new Supplier { SupplierId = new Guid("22222222-2222-2222-2222-222222222222"), SupplierName = "Fresh Farm Ltd", ContactPerson = "Alice Green", Category = Category.FoodAndBeverages, Description = "Fresh fruits and vegetables", PhoneNumber = "9876543211", Email = "alice@freshfarm.com" },
                                new Supplier { SupplierId = new Guid("33333333-3333-3333-3333-333333333333"), SupplierName = "HomeStyle", ContactPerson = "Bob Smith", Category = Category.HomeAndLiving, Description = "Kitchen and home appliances", PhoneNumber = "9876543212", Email = "bob@homestyle.com" },
                                new Supplier { SupplierId = new Guid("44444444-4444-4444-4444-444444444444"), SupplierName = "FashionHub", ContactPerson = "Carol White", Category = Category.ClothingAndFashion, Description = "Clothing and fashion accessories", PhoneNumber = "9876543213", Email = "carol@fashionhub.com" },
                                new Supplier { SupplierId = new Guid("55555555-5555-5555-5555-555555555555"), SupplierName = "Office Essentials", ContactPerson = "David Brown", Category = Category.HomeAndLiving, Description = "Office supplies and stationery", PhoneNumber = "9876543214", Email = "david@officeessentials.com" }
                );
           } 
        }

        public class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> orderBuilder)  //The method should be named Configure instead of any other like OrderConfigure, it should be of correct implementation
            {
                orderBuilder.Property(e => e.Id).HasDefaultValue();                
                
                orderBuilder.Property(p => p.Quantity).IsRequired();

                orderBuilder.Property(p => p.OrderStatus).HasConversion<String>().IsRequired();

                orderBuilder.Property(e => e.OrderDate).IsRequired();

                orderBuilder.Property(e => e.ExpectedDeliveryDate).IsRequired();

                orderBuilder.HasData(
                   new Order
                   {
                       Id = 1,
                       ProductName = "Laptop",
                       Quantity = 5,
                       Notes = "Urgent delivery",
                       OrderStatus = OrderStatus.Delivered,
                       OrderDate = new DateOnly(2025, 9, 1),
                       ExpectedDeliveryDate = new DateOnly(2025, 9, 5),
                       SupplierId = new Guid("11111111-1111-1111-1111-111111111111")
                   },
                   new Order
                   {
                       Id = 2,
                       ProductName = "Organic Apples",
                       Quantity = 100,
                       Notes = "For fresh stock",
                       OrderStatus = OrderStatus.Returned,
                       OrderDate = new DateOnly(2025, 9, 2),
                       ExpectedDeliveryDate = new DateOnly(2025, 9, 6),
                       SupplierId = new Guid("22222222-2222-2222-2222-222222222222"),
                       CustomerId = 3,
                   },
                   new Order
                   {
                       Id = 3,
                       ProductName = "Office Chairs",
                       Quantity = 10,
                       Notes = "",
                       OrderStatus = OrderStatus.Cancelled,
                       OrderDate = new DateOnly(2025, 9, 3),
                       ExpectedDeliveryDate = new DateOnly(2025, 9, 10),
                       SupplierId = new Guid("33333333-3333-3333-3333-333333333333"),
                       CustomerId = 2,
                   }
                );
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<Supplier>()
                .HasMany(o => o.Orders)
                .WithOne(s => s.Supplier)
                .HasForeignKey(f => f.SupplierId)
                .IsRequired();

            modelBuilder.Entity<AppUsers>()
                .HasMany(o => o.Orders)
                .WithOne(s => s.Customer)
                .HasForeignKey(f => f.CustomerId)
                .IsRequired(false);
        }
       public DbSet<AppUsers> AppUsers { get; set;} 
       public DbSet<Product> Products { get; set;}
       public DbSet<Supplier> Suppliers {  get; set;} 
       public DbSet<Order> Orders { get; set;}
       
    }
}
