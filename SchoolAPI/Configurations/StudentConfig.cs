using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Persistence.Entities;

namespace SchoolAPI.Configurations
{
    public class StudentConfig: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student").HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("student_id");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.FirstMidName).HasColumnName("first_mid_name");
            builder.Property(x => x.EnrollmentDate).HasColumnName("enrollment_date");
        }
    }
}
