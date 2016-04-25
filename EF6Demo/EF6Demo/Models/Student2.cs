using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Student2 : Person
    {
        public virtual Grade Grade { get; set; }

        public virtual StudentFile File { get; set; }

        public List<Course> Courses { get; set; }

        // 1-0
        public int? GradeID { get; set; }

        // 1-1
        [Required]
        public int FileID { get; set; }
    }
}