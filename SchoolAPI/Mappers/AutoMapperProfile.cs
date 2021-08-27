using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SchoolAPI.Models.Course;
using SchoolAPI.Models.Instructor;
using SchoolAPI.Models.Student;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // map instructor vs instructor view model
            CreateMap<Instructor, InstructorViewModel>()
                .ForMember(
                d => d.FullName, 
                o => o.MapFrom(s => $"{s.LastName}   {s.FirstMidName}"))
                .ForMember(
                    d => d.Course,
                    o => o.MapFrom(i => i.CourseAssignment.Select(ca => new CourseDepartmentModel()
                    {
                        CourseId = ca.CourseID,
                        Title = ca.Course.Title,
                        Name = ca.Course.Department.Name
                    }))
                    )
                .ForMember(
                    d => d.Location,
                    o => o.MapFrom(i => i.OfficeAssignment.Location)
                ).ReverseMap();
            // map instructor vs instructor create request
            CreateMap<InstructorCreateRequest, Instructor>().ForMember(
                d => d.OfficeAssignment,
                o => o.MapFrom(icr => new OfficeAssignment()
                {
                    Location = icr.Location
                })
            );
            // map instructor vs instructor update request
            CreateMap<Instructor, InstructorUpdateRequest>().ForMember(
                    d => d.Location, 
                    o => o.MapFrom(src => src.OfficeAssignment.Location))
                .ReverseMap();
            // map student vs student view model
            CreateMap<Student, StudentViewModel>()
                .ForMember(
                    d => d.GradeCount,
                    o => o.MapFrom(i => i.Enrollments.Count()))
                .ForMember(
                    d => d.Course,
                    o => o.MapFrom(i => i.Enrollments.Select(ca => new CourseCustomView()
                    {
                        CourseId = ca.Course.CourseID,
                        Title = ca.Course.Title,
                        Grade = ca.Grade
                    }))
                ).ReverseMap();
            // map student vs student create request
            CreateMap<StudentCreateRequest, Student>();
            // map student vs student update request
            CreateMap<StudentUpdateRequest, Student>();
            // map course vs course view model
            CreateMap<Course, CourseViewModel>()
                .ForMember(
                    d => d.Name,
                    o => o.MapFrom(i => i.Department.Name)
                    ).ForMember(
                    d => d.Budget,
                    o => o.MapFrom(i => i.Department.Budget)
                ).ForMember(
                    d => d.StartDate,
                    o => o.MapFrom(i => i.Department.StartDate)
                ).ReverseMap();
        }
    }
}
