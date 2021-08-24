using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public InstructorService(SchoolContext context)
        {
            _context = context;
        }
        public async Task<int> Create(InstructorCreateRequest request)
        {
            var instructor = new Instructor()
            {
                LastName = request.LastName,
                FirstMidName = request.FirstMidName,
                HireDate = request.HireDate,
                OfficeAssignment = new OfficeAssignment()
                {
                    Location = request.Location
                }
            };
            await _context.Instructors.AddAsync(instructor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(InstructorUpdateRequest request)
        {
            var instructor = await _context.Instructors.FindAsync(request.ID);
            var offAssign = await _context.OfficeAssignments.FirstOrDefaultAsync(x => x.InstructorID == request.ID);
            if (instructor == null || offAssign == null) throw new SchoolException($"Cannot find a instructor with id: {request.ID}");
            instructor.LastName = request.LastName;
            instructor.FirstMidName = request.FirstMidName;
            instructor.HireDate = request.HireDate;
            offAssign.Location = request.Location;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int instructorId)
        {
            var instructor = await _context.Instructors.FindAsync(instructorId);
            if (instructor == null) throw new SchoolException($"Cannot find a instructor: {instructorId}");
            _context.Instructors.Remove(instructor);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<InstructorViewModel>> GetAll()
        {
            IQueryable<InstructorViewModel> instructor = _context.Instructors
                .Include(x => x.OfficeAssignment)
                .Include(x => x.CourseAssignment)
                .ThenInclude(x => x.Course)
                .Select(x => new InstructorViewModel()
                {
                    ID = x.ID,
                    LastName = x.LastName,
                    FirstMidName = x.FirstMidName,
                    HireDate = x.HireDate,
                    FullName = x.FullName,
                    Location = x.OfficeAssignment.Location,
                    Title = x.CourseAssignment.Select(ca => ca.Course.Title)
                });
            return await instructor.AsNoTracking().ToListAsync();
        }

        public async Task<InstructorViewModel> GetById(int instructorId)
        {
            var instructor = await _context.Instructors.FindAsync(instructorId);
            var offAssign = await _context.OfficeAssignments.FirstOrDefaultAsync(x => x.InstructorID == instructorId);
            var instructorViewModel = new InstructorViewModel()
            {
                ID = instructor.ID,
                LastName = instructor.LastName,
                FirstMidName = instructor.FirstMidName,
                HireDate = instructor.HireDate,
                FullName = instructor.FullName,
                Location = offAssign.Location
            };
            return instructorViewModel;
        }


        // sortOrder = lastname, firstmidname or location
        public async Task<List<InstructorViewModel>> GetAllPaging(string sortOrder, string keyword, int pageIndex,
            int pageSize)
        {
            // select join
            var query = from i in _context.Instructors
                join o in _context.OfficeAssignments on i.ID equals o.InstructorID
                select new { i, o};
            // filter
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.i.LastName.Contains(keyword)|| x.i.FirstMidName.Contains(keyword) || x.o.Location.Contains(keyword));
            }
            // sort
            switch (sortOrder)
            {
                case "lastname":
                    query = query.OrderByDescending(s => s.i.LastName);
                    break;
                case "firstmidname":
                    query = query.OrderByDescending(s => s.i.FirstMidName);
                    break;
                case "location":
                    query = query.OrderByDescending(s => s.o.Location);
                    break;
                default:
                    query = query.OrderBy(s => s.i.ID);
                    break;
            }
            // paging
            var data = query.Skip((pageIndex - 1)*pageSize).Take(pageSize).Select(x => new InstructorViewModel()
            {
                ID = x.i.ID,
                LastName = x.i.LastName,
                FirstMidName = x.i.FirstMidName,
                FullName = x.i.FullName,
                Location = x.o.Location
            });
            // select and projection
            return await data.AsNoTracking().ToListAsync();
        }
    }
}
