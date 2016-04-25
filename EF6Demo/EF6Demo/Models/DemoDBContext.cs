﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext() : base("DemoConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DemoDBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(s => s.HasMaxLength(100));
            modelBuilder.HasDefaultSchema("DemoSchema");
            modelBuilder.Conventions.Add(new SchemaConvention());

        }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}