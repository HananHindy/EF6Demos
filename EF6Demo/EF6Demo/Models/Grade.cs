using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public string GradeName { get; set; }
        public int TestProperty { get; set; }
    }
}