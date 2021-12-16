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

    }
}
