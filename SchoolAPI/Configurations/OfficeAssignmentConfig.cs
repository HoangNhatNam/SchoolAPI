using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class OfficeAssignmentConfig: IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.ToTable("OfficeAssignment").HasKey(x => x.InstructorID);
            builder.Property(x => x.InstructorID).HasColumnName("instructor_id");
            builder.Property(x => x.Location).HasColumnName("location");
        }
    }
}
