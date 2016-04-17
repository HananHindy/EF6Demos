using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Student
    {
        /// <summary>
        /// Should use same pattern either ID or Property_Id
        /// For Demo Usage only
        /// </summary>
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}