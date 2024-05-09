using Microsoft.EntityFrameworkCore;
using ProniaMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Data.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
            
        
    }
}
