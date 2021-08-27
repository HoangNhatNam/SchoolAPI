using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Models.Student
{
    public class CourseCustomView
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Grade? Grade { get; set; }
    }
}
