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
    public class InstructorController : ControllerBase
    {
        private readonly SchoolContext _context;
        public InstructorController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<InstructorModel> ListInstructor()
        {
            IQueryable<InstructorModel> model = _context.Instructors
                .Include(x => x.OfficeAssignment)
                .Include(x => x.CourseAssignment)
                .ThenInclude(x => x.Count)
                .Select(x => new InstructorModel()
                {
                    LastName = x.LastName,
                    FirstMidName = x.FirstMidName,
                    HireDate = x.HireDate,
                    Location = x.OfficeAssignment.Location,
                    Title = x.CourseAssignment.First().Course.Title
                });

            return model;
        }
    }
}
