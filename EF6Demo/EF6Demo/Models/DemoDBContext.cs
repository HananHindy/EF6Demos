using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class DemoDBContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}