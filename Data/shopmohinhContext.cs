using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopmohinh.Models;

namespace shopmohinh.Data
{
    public class shopmohinhContext : DbContext
    {
        public shopmohinhContext (DbContextOptions<shopmohinhContext> options)
            : base(options)
        {
        }

        public DbSet<shopmohinh.Models.fig> fig { get; set; }
    }
}
