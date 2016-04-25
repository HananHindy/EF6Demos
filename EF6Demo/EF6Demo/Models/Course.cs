using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string CourseTitle { get; set; }
        public string CourseObjective { get; set; }

        public string CourseDescription { get; set; }

        public List<Student2> Students { get; set; }
    }
}