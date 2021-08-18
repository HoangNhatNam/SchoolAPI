using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public IEnumerable<StudentModel> ListUser()
        {
            IQueryable<StudentModel> model = _context.Students
                .Include(x => x.Enrollments)
                .Select(x => new StudentModel()
                {
                    LastName = x.LastName,
                    FirstMidName = x.FirstMidName,
                    GradeCount = x.Enrollments.Count
                });
            return model;
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
        //public IEnumerable<StudentModel> ListFilterStudent(string searchString, int page, int pageSize)
        //{
        //    IQueryable<UserViewModel> model;
        //    model = from a in db.Users
        //        join b in db.DonVis on a.DonViID equals b.DonViID
        //        join c in db.Lops on a.LopID equals c.LopID
        //        join d in db.VaiTroes on a.VaiTroID equals d.VaiTroID
        //        select new StudentModel()
        //        {
        //            UserID = a.UserID,
        //            Email = a.Email,
        //            UserName = a.UserName,
        //            TenDonVi = b.TenDonVi,
        //            TenLop = c.TenLop,
        //            TenVaiTro = d.TenVaiTro
        //        };
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.UserName.Contains(searchString) || x.Email.Contains(searchString)
        //                                                                   || x.TenVaiTro.Contains(searchString) || x.TenDonVi.Contains(searchString) || x.TenLop.Contains(searchString));
        //    }
        //    return model.OrderBy(x => x.TenVaiTro).ToPagedList(page, pageSize);
        //}
    }
}
