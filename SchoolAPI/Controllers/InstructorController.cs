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
        public List<InstructorModel> Instructor { get; set; }
        [HttpGet]
        public async Task ListInstructor()
        {
            IQueryable<InstructorModel> instructor = _context.Instructors
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

            Instructor = await instructor.AsNoTracking().ToListAsync();
        }
    }
}
