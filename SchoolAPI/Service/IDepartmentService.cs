using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models.Department;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public interface IDepartmentService
    {
        Task<int> Create(DepartmentCreateRequest request);
        Task<int> Update(DepartmentUpdateRequest request);
        Task<int> Delete(int departmentId);
        bool VerifyName(string name);
        Task<DepartmentViewModel> GetById(int departmentId);
        Task<List<DepartmentViewModel>> GetAll();
        Task<List<DepartmentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize);
    }
}
