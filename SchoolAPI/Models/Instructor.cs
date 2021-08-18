using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }

        public ICollection<CourseAssignment> CourseAssignment { get; set; }
    }
}
