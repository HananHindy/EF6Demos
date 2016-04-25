using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Teacher : Person
    { 
        public string Title { get; set; }
    }
}