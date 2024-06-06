using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLCoffee.Models;

namespace QLCoffee.Data
{
    public class QLCoffeeContext : DbContext
    {
        public QLCoffeeContext (DbContextOptions<QLCoffeeContext> options)
            : base(options)
        {
        }

        public DbSet<QLCoffee.Models.QLNhanVien> QLNhanVien { get; set; } = default!;
        public DbSet<QLCoffee.Models.QLDoUong> QLDoUong { get; set; } = default!;
        public DbSet<QLCoffee.Models.QLHoaDon> QLHoaDon { get; set; } = default!;
    }
}
