using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public interface IStudentService
    {
        Task<int> Create(StudentCreateRequest request);
        Task<int> Update(StudentUpdateRequest request);
        Task<int> Delete(int studentId);
        Task<bool> CourseAssign(int studentId, int courseId);
        Task<List<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int studentId);
        bool VerifyName(string lastName, string firstMidName);
        Task<List<StudentViewModel>> GetByIdCourse(int courseId);
        Task<List<StudentViewModel>> GetByGrade(Grade grade);
        Task<List<StudentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize);
    }
}
