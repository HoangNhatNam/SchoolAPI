using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class CourseAssignment
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
