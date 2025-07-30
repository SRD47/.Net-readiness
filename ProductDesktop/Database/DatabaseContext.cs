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

        public class UserConfiguration : IEntityTypeConfiguration<Users>
        {
            public void Configure(EntityTypeBuilder<Users>entity)
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
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
       public DbSet<Users> Users {get; set;} 

    }
}
