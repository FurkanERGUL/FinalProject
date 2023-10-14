using FinalProject.CORE.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Konu> Konus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasMany(e => e.Makales)
                .WithOne(e => e.AppUser)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();

            builder.Entity<Konu>()
                .HasMany(e => e.Makales)
                .WithOne(e => e.Konu)
                .HasForeignKey(e => e.KonuId)
                .IsRequired();
            base.OnModelCreating(builder);

            
        }
    }
}
