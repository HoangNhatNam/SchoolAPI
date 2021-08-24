using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Models.Instructor
{
    public class InstructorCreateRequest
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }
        public string Location { get; set; }
    }
}
