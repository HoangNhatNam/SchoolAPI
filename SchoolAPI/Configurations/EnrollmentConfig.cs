using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class EnrollmentConfig: IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment").HasKey(x => x.EnrollmentID);
            builder.Property(x => x.Grade).HasColumnType("nvarchar(50)");
            builder.HasOne(x => x.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseID).HasPrincipalKey(c => c.CourseID);
            builder.HasOne(x => x.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentID).HasPrincipalKey(s => s.ID);
            builder.Property(x => x.EnrollmentID).HasColumnName("enrollment_id");
            builder.Property(x => x.CourseID).HasColumnName("course_id");
            builder.Property(x => x.StudentID).HasColumnName("student_id");
            builder.Property(x => x.Grade).HasColumnName("grade");
        }
    }
}
