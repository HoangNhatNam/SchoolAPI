using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolContext _context;
        public CourseController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<CourseModel> ListCourse()
        {
            IQueryable<CourseModel> model = _context.Courses
                .Include(x => x.Department)
                .Select(x => new CourseModel()
                {
                    CourseID = x.CourseID,
                    Title = x.Title,
                    Credits = x.Credits,
                    Name = x.Department.Name
                });
            return model;
        }
    }
}
