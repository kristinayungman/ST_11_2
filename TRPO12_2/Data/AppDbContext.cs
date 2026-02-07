using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Polzovat> Polzovats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MKEIMDD;Database=MYZd;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
