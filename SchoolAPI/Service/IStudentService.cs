using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Student;

namespace SchoolAPI.Service
{
    public interface IStudentService
    {
        Task<int> Create(StudentCreateRequest request);
        Task<int> Update(StudentUpdateRequest request);
        Task<int> Delete(int studentId);
        Task<List<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int studentId);
        Task<List<StudentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize);
    }
}
