using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class CourseAssignmentConfig: IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment").HasKey(x => new { x.CourseID, x.InstructorID });
            builder.HasOne(x => x.Instructor).WithMany(i => i.CourseAssignment).HasForeignKey(c => c.InstructorID).HasPrincipalKey(i => i.ID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Course).WithMany(c => c.CourseAssignment).HasForeignKey(c => c.CourseID).HasPrincipalKey(c => c.CourseID).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.CourseID).HasColumnName("course_id");
            builder.Property(x => x.InstructorID).HasColumnName("instructor_id");
        }
    }
}
