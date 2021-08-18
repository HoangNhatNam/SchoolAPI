using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;
        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Student> GetAllStudent()
        {
            return _context.Students.Include(x => x.Enrollments).ToList();
        }
        [HttpGet("{id}")]
        public Student GetStudent(int studentId)
        {
            return _context.Students.Find(studentId);
        }
        [HttpPost]
        public bool InsertStudent(Student studentItem)
        {
            bool status;
            try
            {
                _context.Students.Add(studentItem);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        [HttpPut("{id}")]
        public bool UpdateProduct(int id, Student studentItem)
        {
            bool status;
            try
            {
                Student stuItem = _context.Students.Find(id);
                if (stuItem != null)
                {
                    stuItem.LastName = studentItem.LastName;
                    stuItem.FirstMidName = studentItem.LastName;
                    stuItem.EnrollmentDate = studentItem.EnrollmentDate;
                    _context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Student stuItem = _context.Students.Find(id);
                if (stuItem != null)
                {
                    _context.Students.Remove(stuItem);
                    _context.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
