using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models.Course;
using SchoolAPI.Models.Instructor;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.EF;
using Grade = SchoolAPI.Persistence.Entities.Grade;

namespace SchoolAPI.Service
{
    public class CourseService: ICourseService
    {
        private readonly SchoolContext _context;
        public CourseService(SchoolContext context)
        {
            _context = context;
        }
        public Task<int> Create(CourseCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(CourseUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            IQueryable<CourseViewModel> course = _context.Courses
                .Include(x => x.Department)
                .Select(x => new CourseViewModel()
                {
                    CourseID = x.CourseID,
                    Title = x.Title,
                    Credits = x.Credits,
                    Name = x.Department.Name,
                    Budget = x.Department.Budget,
                    StartDate = x.Department.StartDate
                });
            return await course.AsNoTracking().ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetCourseByIdInstructor(int instructorId)
        {
            //IQueryable<CourseViewModel> course = _context.Courses
            //    .Include(x => x.CourseAssignment)
            //    .Select(x => new CourseViewModel()
            //    {
            //        CourseID = x.CourseID,
            //        Title = x.Title,
            //        Credits = x.Credits,
            //    });
            var query = from c in _context.Courses
                join ca in _context.CourseAssignments on c.CourseID equals ca.CourseID
                where ca.InstructorID == instructorId
                select new CourseViewModel()
                {
                    CourseID = c.CourseID,
                    Title = c.Title,
                    Credits = c.Credits,
                };
            return await query.AsNoTracking().ToListAsync();
        }

        public Task<List<CourseViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
