using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Demo_MVC.Models
{
    public class DemoContext : DbContext
    {

        public DemoContext() : base("name = DemoContext") { 
        
        
        
        }

      public DbSet<Demo> Demos { get; set; }   
        
        public DbSet<Product> Products { get; set; }    
    }
}