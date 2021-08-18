using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public int? Grade { get; set; }
        public int GradeCount { get; set; }
        public int EnrollmentCount { get; set; }
    }
}
