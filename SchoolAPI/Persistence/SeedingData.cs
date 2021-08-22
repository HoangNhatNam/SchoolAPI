using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Persistence
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new { ID = 1, LastName = "Hoang", FirstMidName = "Nhat Nam", EnrollmentDate = DateTime.Now },
                new { ID = 2, LastName = "Thi", FirstMidName = "Nhat Minh", EnrollmentDate = DateTime.Now },
                new { ID = 3, LastName = "Ngo", FirstMidName = "Viet Hung", EnrollmentDate = DateTime.Now },
                new { ID = 4, LastName = "Luu", FirstMidName = "Duc Thai", EnrollmentDate = DateTime.Now }
                );
            modelBuilder.Entity<Enrollment>().HasData(
                new { EnrollmentID = 1, CourseID = 2, StudentID = 1, Grade = Grade.A },
                new { EnrollmentID = 2, CourseID = 3, StudentID = 1, Grade = Grade.C },
                new { EnrollmentID = 3, CourseID = 4, StudentID = 2, Grade = Grade.D },
                new { EnrollmentID = 4, CourseID = 5, StudentID = 2, Grade = Grade.A },
                new { EnrollmentID = 5, CourseID = 1, StudentID = 3, Grade = Grade.B },
                new { EnrollmentID = 6, CourseID = 2, StudentID = 3, Grade = Grade.None },
                new { EnrollmentID = 7, CourseID = 4, StudentID = 3, Grade = Grade.E }
            );
            modelBuilder.Entity<Course>().HasData(
                new { CourseID = 1, Title = "Thiet ke mau", Credits = 2000000, DepartmentID = 7 },
                new { CourseID = 2, Title = "Giao duc the chat", Credits = 3000000, DepartmentID = 2 },
                new { CourseID = 3, Title = "Quoc phong", Credits = 4000000, DepartmentID = 3 },
                new { CourseID = 4, Title = "Thiet ke web", Credits = 5000000, DepartmentID = 7 },
                new { CourseID = 5, Title = "Quan tri co so du lieu", Credits = 5000000, DepartmentID = 7 }
            );
            modelBuilder.Entity<Instructor>().HasData(
                new { ID = 1, LastName = "Thach", FirstMidName = "Son Kim Quang", HireDate = DateTime.Now },
                new { ID = 2, LastName = "Vo", FirstMidName = "Ngoc Tam", HireDate = DateTime.Now },
                new { ID = 3, LastName = "Nguyen", FirstMidName = "Van A", HireDate = DateTime.Now },
                new { ID = 4, LastName = "Chi", FirstMidName = "Thoai", HireDate = DateTime.Now }
            );
            modelBuilder.Entity<CourseAssignment>().HasData(
                new { CourseID = 1, InstructorID = 2 },
                new { CourseID = 5, InstructorID = 1 },
                new { CourseID = 3, InstructorID = 2 },
                new { CourseID = 2, InstructorID = 3 },
                new { CourseID = 4, InstructorID = 1 }
            );
            modelBuilder.Entity<Department>().HasData(
                new { DepartmentID = 1, Name = "English", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 },
                new { DepartmentID = 2, Name = "Computer Science", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 2 },
                new { DepartmentID = 3, Name = "Scince", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 3 },
                new { DepartmentID = 4, Name = "Social Studies", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 },
                new { DepartmentID = 5, Name = "Theology", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 2 },
                new { DepartmentID = 6, Name = "Mathematics", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 3 },
                new { DepartmentID = 7, Name = "IT", Budget = 3000000m, StartDate = DateTime.Now, InstructorID = 1 }
            );
        }
    }
}
