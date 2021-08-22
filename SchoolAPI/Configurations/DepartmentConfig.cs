using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class DepartmentConfig: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(x => x.Instructor).WithMany().HasForeignKey(d => d.InstructorID);
            builder.Property(x => x.DepartmentID).HasColumnName("department_id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Budget).HasColumnName("budget").HasColumnType("decimal");
            builder.Property(x => x.StartDate).HasColumnName("start_date");
            builder.Property(x => x.InstructorID).HasColumnName("instructor_id");
        }
    }
}
