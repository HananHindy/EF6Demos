using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class CustomDBConfigurations : DbConfiguration
    {
        public CustomDBConfigurations()
        {
            //var entities = new[]
            //{
            //    new CustomPluralizationEntry("Class", "MyClass"),
            //    new CustomPluralizationEntry("Student","Students")
            //};

            //SetPluralizationService(new EnglishPluralizationService(entities));
        }
    }

    //public class CustomPluralizationSerive : IPluralizationService
    //{
    //    public string Pluralize(string word)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public string Singularize(string word)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}