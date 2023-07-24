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

        public DbSet<QRBankPayAPI.Data.Models.Client> Clients { get; set; } = default!;
    }
}
