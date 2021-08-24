using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Exceptions;
using SchoolAPI.Models;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.EF;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public class StudentService: IStudentService
    {
        private readonly SchoolContext _context;
        public StudentService(SchoolContext context)
        {
            _context = context;
        }
        public async Task<int> Create(StudentCreateRequest request)
        {
            var student = new Student()
            {
                LastName = request.LastName,
                FirstMidName = request.FirstMidName,
                EnrollmentDate = request.EnrollmentDate,
            };
            await _context.Students.AddAsync(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(StudentUpdateRequest request)
        {
            var student = await _context.Students.FindAsync(request.ID);
            if (student == null) throw new SchoolException($"Cannot find a student with id: {request.ID}");
            student.LastName = request.LastName;
            student.FirstMidName = request.FirstMidName;
            student.EnrollmentDate = request.EnrollmentDate;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) throw new SchoolException($"Cannot find a instructor: {studentId}");
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAll()
        {
            IQueryable<StudentViewModel> student = _context.Students
                .Include(x => x.Enrollments)
                .Select(x => new StudentViewModel()
                {
                    ID = x.ID,
                    LastName = x.LastName,
                    FirstMidName = x.FirstMidName,
                    GradeCount = x.Enrollments.Count,
                    EnrollmentDate = x.EnrollmentDate,
                    Title = x.Enrollments.Select(x => x.Course.Title)
                    //Grade = x.Enrollments.Select(x => x.Grade),
                });
            return await student.ToListAsync();
        }

        public async Task<StudentViewModel> GetById(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var studentViewModel = new StudentViewModel()
            {
                ID = student.ID,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate
            };
            return studentViewModel;
        }
        // sortOrder = lastname, firstmidname or grade
        public async Task<List<StudentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize)
        {
            IQueryable<StudentViewModel> student = _context.Students
                .Include(x => x.Enrollments)
                .Select(x => new StudentViewModel()
                {
                    ID = x.ID,
                    LastName = x.LastName,
                    FirstMidName = x.FirstMidName,
                    GradeCount = x.Enrollments.Count,
                    EnrollmentDate = x.EnrollmentDate
                });
            if (!string.IsNullOrEmpty(keyword))
            {
                student = student.Where(x => x.LastName.Contains(keyword) || x.FirstMidName.Contains(keyword) || x.GradeCount.ToString().Contains(keyword));
            }
            switch (sortOrder)
            {
                case "lastname":
                    student = student.OrderByDescending(s => s.LastName);
                    break;
                case "firstmidname":
                    student = student.OrderByDescending(s => s.FirstMidName);
                    break;
                case "grade":
                    student = student.OrderByDescending(s => s.Grade);
                    break;
                default:
                    student = student.OrderByDescending(s => s.ID);
                    break;
            }

            student.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return await student.AsNoTracking().ToListAsync();
        }
    }
}
