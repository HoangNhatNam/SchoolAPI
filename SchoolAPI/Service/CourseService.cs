using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Exceptions;
using SchoolAPI.Models.Course;
using SchoolAPI.Models.Instructor;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.EF;
using SchoolAPI.Persistence.Entities;
using Grade = SchoolAPI.Persistence.Entities.Grade;

namespace SchoolAPI.Service
{
    public class CourseService: ICourseService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        public CourseService(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(CourseCreateRequest request)
        {
            var course = _mapper.Map<Course>(request);
            await _context.Courses.AddAsync(course);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(CourseUpdateRequest request)
        {
            var course = await _context.Courses.FindAsync(request.CourseID);
            if (course == null) throw new SchoolException($"Cannot find a course with id: {request.CourseID}");
            _mapper.Map(request, course);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) throw new SchoolException($"Cannot find a course: {courseId}");
            _context.Courses.Remove(course);
            return await _context.SaveChangesAsync();
        }

        public bool VerifyName(string title, int departmentId)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Title == title && x.DepartmentID == departmentId);
            if (course != null)
            {
                return true;
            }
            return false;
        }

        public async Task<CourseViewModel> GetById(int courseId)
        {
            var course = _context.Courses
                .Where(x => x.CourseID == courseId);
            if (course == null) throw new SchoolException($"Cannot find a course with id: {courseId}");
            var courseViewModel = await _mapper.ProjectTo<CourseViewModel>(course).FirstOrDefaultAsync();
            return courseViewModel;
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            return await _mapper.ProjectTo<CourseViewModel>(_context.Courses)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetCourseByIdInstructor(int instructorId)
        {
            // query
            var course = _context.CourseAssignments
                .Where(x => x.InstructorID == instructorId)
                .Select(x => x.Course);
            // mapping
            var courseViewModel = _mapper.ProjectTo<CourseViewModel>(course);
            return await courseViewModel.AsNoTracking().ToListAsync();
        }

        public Task<List<CourseViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
