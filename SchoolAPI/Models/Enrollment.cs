using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public enum Grade
    {
        None, A, B, C, D, E
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Grade Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
