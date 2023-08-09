using Microsoft.EntityFrameworkCore;
using QRBankPayAPI.Data.Models;

namespace QRBankPayAPI.Data
{
    public class QRBankPayDbContext : DbContext
    {
        public QRBankPayDbContext(DbContextOptions<QRBankPayDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));

            base.OnModelCreating(modelBuilder);
        }
    }
}
