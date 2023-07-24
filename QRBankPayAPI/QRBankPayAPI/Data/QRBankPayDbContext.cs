using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QRBankPayAPI.Data.Models;

namespace QRBankPayAPI.Data
{
    public class QRBankPayDbContext : DbContext
    {
        public QRBankPayDbContext (DbContextOptions<QRBankPayDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            base.OnModelCreating(modelBuilder);
        }
    }
}
