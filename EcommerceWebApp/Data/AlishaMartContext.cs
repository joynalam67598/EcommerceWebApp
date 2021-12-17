using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Data
{
    public class AlishaMartContext : DbContext
    {
        public AlishaMartContext(DbContextOptions<AlishaMartContext> options) : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        
        public DbSet<Brands> Brands { get; set; }
        
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasIndex(p => new { p.CategoryName })
                .IsUnique(true);
            modelBuilder.Entity<Brands>()
                .HasIndex(p => new { p.BrandName })
                .IsUnique(true);
            modelBuilder.Entity<Products>()
                .HasIndex(p => new { p.ProductName,p.ProductCode })
                .IsUnique(true);
        }

    }
}
