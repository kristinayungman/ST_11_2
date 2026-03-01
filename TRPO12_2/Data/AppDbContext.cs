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
       // public DbSet<Polzovat> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Polzovat> Polzovats { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MKEIMDD;Database=MYZd;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Polzovat>() // отношение один-к-одному
           .HasOne(s => s.Passport)
           .WithOne(ps => ps.Student)
           .HasForeignKey<Passport>(ps => ps.PolzovatId);

            modelBuilder.Entity<Polzovat>() // отношение один-к-одному
            .HasOne(s => s.Profile)
            .WithOne(ps => ps.Polzovat)
            .HasForeignKey<UserProfile>(ps => ps.PolzovatId);

            modelBuilder.Entity<Role>() // отношение один-ко-многим
            .HasMany(g => g.Polzovats)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);
        }

    }
}
