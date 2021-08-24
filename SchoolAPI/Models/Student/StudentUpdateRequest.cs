using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Student
{
    public enum Grade
    {
        None, A, B, C, D, E
    }
    public class StudentUpdateRequest
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Grade Grade { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}
