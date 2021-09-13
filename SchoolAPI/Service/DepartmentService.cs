using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Exceptions;
using SchoolAPI.Models.Department;
using SchoolAPI.Persistence.EF;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(DepartmentCreateRequest request)
        {
            var department = _mapper.Map<Department>(request);
            await _context.Departments.AddAsync(department);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(DepartmentUpdateRequest request)
        {
            var department = await _context.Departments.FindAsync(request.DepartmentID);
            if (department == null) throw new SchoolException($"Cannot find a department with id: {request.DepartmentID}");
            _mapper.Map(request, department);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null) throw new SchoolException($"Cannot find a department: {departmentId}");
            _context.Departments.Remove(department);
            return await _context.SaveChangesAsync();
        }

        public bool VerifyName(string name)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Name == name);
            if (department != null)
            {
                return true;
            }
            return false;
        }

        public async Task<DepartmentViewModel> GetById(int departmentId)
        {
            var department = _context.Departments
                .Where(x => x.DepartmentID == departmentId);
            if (department == null) throw new SchoolException($"Cannot find a department with id: {departmentId}");
            var departmentViewModel = await _mapper.ProjectTo<DepartmentViewModel>(department).FirstOrDefaultAsync();
            return departmentViewModel;
        }

        public async Task<List<DepartmentViewModel>> GetAll()
        {
            return await _mapper.ProjectTo<DepartmentViewModel>(_context.Departments)
                .AsNoTracking().ToListAsync();
        }

        public Task<List<DepartmentViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
