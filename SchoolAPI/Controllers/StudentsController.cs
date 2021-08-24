using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.EF;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentCreateRequest request)
        {
            var result = await _studentService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StudentUpdateRequest request)
        {
            var result = await _studentService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok(result);
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
