using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SchoolAPI.Models.Student
{
    [Bind("CourseId,StudentId")]
    public class CourseAssign
    {
        [BindRequired]
        public int CourseId { get; set; }
        [BindRequired]
        public int StudentId { get; set; }
    }
}
