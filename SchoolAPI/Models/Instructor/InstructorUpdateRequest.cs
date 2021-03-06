using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models.Instructor
{
    public class InstructorUpdateRequest
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the last name")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 10")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the first mid name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "Please enter enrollment date")]
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the location")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 10")]
        public string Location { get; set; }
    }
}
