using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DemoDBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
          
        }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}