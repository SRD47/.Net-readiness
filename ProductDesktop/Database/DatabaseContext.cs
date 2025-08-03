using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

                entity.HasData(new AppUsers {Id = 1, Name = "Admin",Username="Admin" ,Password = "admin", Roles = Roles.Admin});
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
       public DbSet<AppUsers> AppUsers { get; set;} 

    }
}
