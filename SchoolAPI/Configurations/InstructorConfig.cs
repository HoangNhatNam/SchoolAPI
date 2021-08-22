using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class InstructorConfig: IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor").HasKey(x => x.ID);
            builder.HasOne(x => x.OfficeAssignment).WithOne(o => o.Instructor).HasForeignKey<OfficeAssignment>(i => i.InstructorID);
            builder.Property(x => x.ID).HasColumnName("instructor_id");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
            builder.Property(x => x.HireDate).HasColumnName("hire_date");
        }
    }
}
