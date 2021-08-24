using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Instructor
{
    public class InstructorUpdateRequest
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }
        public string Location { get; set; }
    }
}
