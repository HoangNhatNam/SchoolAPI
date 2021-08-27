using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Models.Student
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int GradeCount { get; set; }
        public IEnumerable<CourseCustomView> Course { get; set; }

    }
}
