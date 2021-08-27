using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Exceptions;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.Entities;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetById(int studentId)
        {
            var student = await _studentService.GetById(studentId);
            if (student == null)
                return BadRequest();
            return Ok(student);
        }
        [HttpGet("GetByCourse/{courseId}")]
        public async Task<IActionResult> GetByIdCourse(int courseId)
        {
            var student = await _studentService.GetByIdCourse(courseId);
            if (student == null)
                return BadRequest();
            return Ok(student);
        }
        [HttpGet("GetByGrade/{grade}")]
        public async Task<IActionResult> GetByGrade(Grade grade)
        {
            var student = await _studentService.GetByGrade(grade);
            if (student == null)
                return BadRequest();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentCreateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // model validation
            if (_studentService.VerifyName(request.LastName, request.FirstMidName))
            {
                return BadRequest($"A user named {request.LastName} {request.FirstMidName} already exists.");
            }
            // action
            var result = await _studentService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StudentUpdateRequest request)
        {
            // model binding
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // action
            var result = await _studentService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut("course/{studentId}/{courseId}")]
        public async Task<IActionResult> CourseAssign(int studentId, int courseId)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _studentService.CourseAssign(studentId, courseId);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            var result = await _studentService.Delete(studentId);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging(string sortOrder, string keyword, int pageIndex,
            int pageSize)
        {
            var students = await _studentService.GetAllPaging(sortOrder, keyword, pageIndex, pageSize);
            return Ok(students);
        }
    }
}
