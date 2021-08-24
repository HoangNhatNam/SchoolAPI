using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Persistence.Entities;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAll();
            return Ok(courses);
        }
        [HttpGet("{instructorId}")]
        public async Task<IActionResult> GetCourseByIdInstructor(int instructorId)
        {
            var courses = await _courseService.GetCourseByIdInstructor(instructorId);
            if (courses == null)
                return BadRequest();
            return Ok(courses);
        }
        [HttpGet("{grade}/abc")]
        public async Task<IActionResult> Test(int grade)
        {
            var courses = await _courseService.Test(grade);
            if (courses == null)
                return BadRequest();
            return Ok(courses);
        }
    }
}
