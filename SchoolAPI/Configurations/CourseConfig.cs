using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class CourseConfig: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course").HasKey(x => x.CourseID);
            builder.HasOne(x => x.Department).WithMany(d => d.Courses).HasForeignKey(c => c.DepartmentID).HasPrincipalKey(d => d.DepartmentID);
            builder.Property(x => x.CourseID).HasColumnName("course_id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.Credits).HasColumnName("credits");
            builder.Property(x => x.DepartmentID).HasColumnName("department_id");
        }
    }
}
