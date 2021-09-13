using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Course;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public interface ICourseService
    {
        Task<int> Create(CourseCreateRequest request);
        Task<int> Update(CourseUpdateRequest request);
        Task<int> Delete(int courseId);
        bool VerifyName(string title, int departmentId);
        Task<CourseViewModel> GetById(int courseId);
        Task<List<CourseViewModel>> GetAll();
        Task<List<CourseViewModel>> GetCourseByIdInstructor(int instructorId);
        Task<List<CourseViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize);
    }
}
