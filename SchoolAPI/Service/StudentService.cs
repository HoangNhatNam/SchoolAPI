using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        public StudentService(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(StudentCreateRequest request)
        {
            var student = _mapper.Map<Student>(request);
            await _context.Students.AddAsync(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(StudentUpdateRequest request)
        {
            var student = await _context.Students.FindAsync(request.ID);
            if (student == null) throw new SchoolException($"Cannot find a student with id: {request.ID}");
            _mapper.Map(request, student);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) throw new SchoolException($"Cannot find a instructor: {studentId}");
            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> CourseAssign(int studentId, int courseId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return false;
            }
            var enrollment = new Enrollment()
            {
                StudentID = studentId,
                CourseID = courseId,
                Grade = Grade.None
            };
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudentViewModel>> GetAll()
        {
            return await _mapper.ProjectTo<StudentViewModel>(_context.Students)
                .AsNoTracking().ToListAsync();
        }

        public async Task<StudentViewModel> GetById(int studentId)
        {
            var student = _context.Students
                .Include(x => x.Enrollments)
                .Where(x => x.ID == studentId);
            if (student == null) throw new SchoolException($"Cannot find a student with id: {studentId}");
            var studentViewModel = await _mapper.ProjectTo<StudentViewModel>(student).FirstOrDefaultAsync();
            return studentViewModel;
        }

        public bool VerifyName(string lastName, string firstMidName)
        {
            var student =  _context.Students.FirstOrDefault(x => x.LastName == lastName && x.FirstMidName == firstMidName);
            if (student != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<StudentViewModel>> GetByIdCourse(int courseId)
        {
            //IQueryable<StudentViewModel> student = _context.Students
            //    .Include(x => x.Enrollments.Where(a => a.CourseID.Equals(courseId)))
            //    .ThenInclude(x => x.Course)
            //    .Select(x => new StudentViewModel()
            //    {
            //        ID = x.ID,
            //        LastName = x.LastName,
            //        FirstMidName = x.FirstMidName,
            //        GradeCount = x.Enrollments.Count,
            //        EnrollmentDate = x.EnrollmentDate,
            //        Title = x.Enrollments.Select(e => e.Course.Title)
            //    });
            var student = from s in _context.Students
                join e in _context.Enrollments on s.ID equals e.StudentID
                join c in _context.Courses on e.CourseID equals c.CourseID
                where e.CourseID == courseId
                select new StudentViewModel()
                {
                    ID = s.ID,
                    LastName = s.LastName,
                    FirstMidName = s.FirstMidName,
                    GradeCount = s.Enrollments.Count,
                    EnrollmentDate = s.EnrollmentDate,
                    Course = s.Enrollments.Select(e => new CourseCustomView()
                    {
                        CourseId = e.CourseID,
                        Title = e.Course.Title,
                        Grade = e.Grade,
                    })
                };
            var student1 = _context.Students
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Course)
                .Select(x => x.Enrollments.Where(x => x.CourseID == courseId));
            // var studentViewModel = _mapper.ProjectTo<StudentViewModel>(student1);
            return await student.AsNoTracking().ToListAsync();
        }

        public async Task<List<StudentViewModel>> GetByGrade(Grade grade)
        {
            var student = from s in _context.Students
                join e in _context.Enrollments on s.ID equals e.StudentID
                where e.Grade.Equals(grade)
                select new StudentViewModel()
                {
                    ID = s.ID,
                    LastName = s.LastName,
                    FirstMidName = s.FirstMidName,
                    GradeCount = s.Enrollments.Count,
                    EnrollmentDate = s.EnrollmentDate,
                    Course = s.Enrollments.Select(e => new CourseCustomView()
                    {
                        Title = e.Course.Title,
                        Grade = e.Grade,
                    })
                };
            // query
            //var student1 = _context.Students
            //    .Include(x => x.Enrollments)
            //    .Select(x => x.Enrollments.Where(e => e.Grade.Equals(grade)));
            // mapping
            // var studentViewModel = _mapper.ProjectTo<StudentViewModel>(student1);
            return await student.AsNoTracking().ToListAsync();
        }

        // sortOrder = lastname, firstname
        public async Task<List<StudentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize)
        {
            // mapping and query
            IQueryable<StudentViewModel> student = _mapper.ProjectTo<StudentViewModel>(_context.Students);
            // filter
            if (!string.IsNullOrEmpty(keyword))
            {
                student = student.Where(x => x.LastName.Contains(keyword) || x.FirstMidName.Contains(keyword) || x.GradeCount.ToString().Contains(keyword));
            }
            // sort
            switch (sortOrder)
            {
                case "lastname":
                    student = student.OrderByDescending(s => s.LastName);
                    break;
                case "firstname":
                    student = student.OrderByDescending(s => s.FirstMidName);
                    break;
                default:
                    student = student.OrderByDescending(s => s.ID);
                    break;
            }
            // paging
            return await student.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }
    }
}
