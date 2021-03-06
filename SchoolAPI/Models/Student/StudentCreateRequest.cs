using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Models.Student
{
    public class StudentCreateRequest
    {
        [Remote(action: "Create", controller: "Students", AdditionalFields = nameof(LastName))]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the last name")]
        [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 10")]
        public string LastName { get; set; }

        [Remote(action: "Create", controller: "Students", AdditionalFields = nameof(FirstMidName))]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the first mid name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "Please enter enrollment date")]
        [DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
    }
}
