using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using SchoolAPI.Persistence;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Persistence.EF
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>(
                eb =>
                {
                    eb.ToTable("Course").HasKey(x => x.CourseID);
                    eb.HasOne(x => x.Department).WithMany(d => d.Courses).HasForeignKey(c => c.DepartmentID).HasPrincipalKey(d => d.DepartmentID);
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.Title).HasColumnName("title");
                    eb.Property(x => x.Credits).HasColumnName("credits");
                    eb.Property(x => x.DepartmentID).HasColumnName("department_id");
                });

            modelBuilder.Entity<Enrollment>(
                eb =>
                {
                    eb.ToTable("Enrollment").HasKey(x => x.EnrollmentID);
                    eb.Property(x => x.Grade).HasColumnType("nvarchar(50)");
                    eb.HasOne(x => x.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseID).HasPrincipalKey(c => c.CourseID);
                    eb.HasOne(x => x.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentID).HasPrincipalKey(s => s.ID);
                    eb.Property(x => x.EnrollmentID).HasColumnName("enrollment_id");
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.StudentID).HasColumnName("student_id");
                    eb.Property(x => x.Grade).HasColumnName("grade");
                });

            modelBuilder.Entity<Instructor>(
                eb =>
                {
                    eb.ToTable("Instructor").HasKey(x => x.ID);
                    eb.HasOne(x => x.OfficeAssignment).WithOne(o => o.Instructor).HasForeignKey<OfficeAssignment>(i => i.InstructorID);
                    eb.Property(x => x.ID).HasColumnName("instructor_id");
                    eb.Property(x => x.LastName).HasColumnName("last_name");
                    eb.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
                    eb.Property(x => x.HireDate).HasColumnName("hire_date");
                });

            modelBuilder.Entity<OfficeAssignment>(
                eb =>
                {
                    eb.ToTable("OfficeAssignment").HasKey(x => x.InstructorID);
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                    eb.Property(x => x.Location).HasColumnName("location");
                });


            modelBuilder.Entity<Student>(
                eb =>
                {
                    eb.ToTable("Student").HasKey(x => x.ID);
                    eb.Property(x => x.ID).HasColumnName("student_id");
                    eb.Property(x => x.LastName).HasColumnName("last_name");
                    eb.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
                    eb.Property(x => x.EnrollmentDate).HasColumnName("enrollment_date");
                });

            modelBuilder.Entity<CourseAssignment>(
                eb => {
                    eb.ToTable("CourseAssignment").HasKey(x => new { x.CourseID, x.InstructorID });
                    eb.HasOne(x => x.Instructor).WithMany(i => i.CourseAssignment).HasForeignKey(c => c.InstructorID).HasPrincipalKey(i => i.ID).OnDelete(DeleteBehavior.Restrict);
                    eb.HasOne(x => x.Course).WithMany(c => c.CourseAssignment).HasForeignKey(c => c.CourseID).HasPrincipalKey(c => c.CourseID).OnDelete(DeleteBehavior.Restrict);
                    eb.Property(x => x.CourseID).HasColumnName("course_id");
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                });

            modelBuilder.Entity<Department>(
                eb => {
                    eb.HasOne(x => x.Instructor).WithMany().HasForeignKey(d => d.InstructorID);
                    eb.Property(x => x.DepartmentID).HasColumnName("department_id");
                    eb.Property(x => x.Name).HasColumnName("name");
                    eb.Property(x => x.Budget).HasColumnName("budget").HasColumnType("decimal");
                    eb.Property(x => x.StartDate).HasColumnName("start_date");
                    eb.Property(x => x.InstructorID).HasColumnName("instructor_id");
                });

            modelBuilder.Seed();
        }
    }
}
