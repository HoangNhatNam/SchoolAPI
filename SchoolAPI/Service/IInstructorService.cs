using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Instructor;

namespace SchoolAPI.Service
{
    public interface IInstructorService
    {
        Task<int> Create(InstructorCreateRequest request);
        Task<int> Update(InstructorUpdateRequest request);
        Task<int> Delete(int instructorId);
        bool VerifyName(string lastName, string firstMidName);
        Task<List<InstructorViewModel>> GetAll();
        Task<InstructorViewModel> GetById(int instructorId);
        Task<List<InstructorViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize);
    }
}
