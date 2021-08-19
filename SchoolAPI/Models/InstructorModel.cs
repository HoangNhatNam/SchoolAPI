using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class InstructorModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseAssignment> CourseAssignment { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<string> ListTitle { get; set; }
    }
}
