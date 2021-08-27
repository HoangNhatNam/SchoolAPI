using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Exceptions;
using SchoolAPI.Models.Instructor;
using SchoolAPI.Persistence.EF;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Service
{
    public class InstructorService: IInstructorService
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;
        public InstructorService(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(InstructorCreateRequest request)
        {
            var instructor = _mapper.Map<Instructor>(request);
            await _context.Instructors.AddAsync(instructor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(InstructorUpdateRequest request)
        {
            var instructor = await _context.Instructors.FindAsync(request.ID);
            var offAssign = await _context.OfficeAssignments.FirstOrDefaultAsync(x => x.InstructorID == request.ID);
            if (instructor == null || offAssign == null) throw new SchoolException($"Cannot find a instructor with id: {request.ID}");
            _mapper.Map(request, instructor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int instructorId)
        {
            var instructor = await _context.Instructors.FindAsync(instructorId);
            if (instructor == null) throw new SchoolException($"Cannot find a instructor: {instructorId}");
            _context.Instructors.Remove(instructor);
            return await _context.SaveChangesAsync();
        }

        public bool VerifyName(string lastName, string firstMidName)
        {
            var instructor = _context.Instructors.FirstOrDefault(x => x.LastName == lastName && x.FirstMidName == firstMidName);
            if (instructor != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<InstructorViewModel>> GetAll()
        {
            return await _mapper.ProjectTo<InstructorViewModel>(_context.Instructors)
                .AsNoTracking().ToListAsync();
        }

        public async Task<InstructorViewModel> GetById(int instructorId)
        {
            var instructor = _context.Instructors
                .Where(x => x.ID == instructorId);
            if (instructor == null) throw new SchoolException($"Cannot find a instructor with id: {instructorId}");
            var instructorViewModel = await _mapper.ProjectTo<InstructorViewModel>(instructor).FirstOrDefaultAsync();
            return instructorViewModel;
        }

        // sortOrder = lastname, firstname or location
        public async Task<List<InstructorViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex,
            int pageSize)
        {
            // mapping and query
            IQueryable<InstructorViewModel> student = _mapper.ProjectTo<InstructorViewModel>(_context.Instructors);
            // filter
            if (!string.IsNullOrEmpty(keyword))
            {
                student = student.Where(x => x.LastName.Contains(keyword) || x.FirstMidName.Contains(keyword) || x.Location.Contains(keyword));
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
