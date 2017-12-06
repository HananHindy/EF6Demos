using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int ID3 { get; set; }

        public string CourseTitle { get; set; }
        public List<Student2> Students { get; set; }
    }
}