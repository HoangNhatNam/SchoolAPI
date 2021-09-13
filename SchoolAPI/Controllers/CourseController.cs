using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Course;
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
        [HttpGet("GetByInstructor/{instructorId}")]
        public async Task<IActionResult> GetCourseByIdInstructor(int instructorId)
        {
            var courses = await _courseService.GetCourseByIdInstructor(instructorId);
            if (courses == null)
                return BadRequest();
            return Ok(courses);
        }
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetById(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var course = await _courseService.GetById(courseId);
            if (course == null)
                return BadRequest();
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseCreateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // model validation
            if (_courseService.VerifyName(request.Title, request.DepartmentID))
            {
                return BadRequest($"A course named {request.Title}, departmentId: {request.DepartmentID} already exists.");
            }
            // action
            var result = await _courseService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CourseUpdateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // action
            var result = await _courseService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            var result = await _courseService.Delete(courseId);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
    }
}
