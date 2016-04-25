using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EF6Demo.Models
{
    public class SchemaConvention : Convention
    {
        public SchemaConvention()
        {
            Types().Where(t => t.GetCustomAttributes(false).OfType<Schema>().Any())
            .Configure(c => c.ToTable(new EnglishPluralizationService().Pluralize(c.ClrType.Name),
                c.ClrType.GetCustomAttribute<Schema>().SchemaName));
        }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Schema : Attribute
    {
        public string SchemaName { get; set; }
        public Schema(string x)
        {
            SchemaName = x;
        }
    }
}