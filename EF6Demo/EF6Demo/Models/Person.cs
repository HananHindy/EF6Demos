using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Person
    {
        public int ID { get; set; }

        public int USID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}