using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Configurations
{
    internal class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {

            builder.HasKey(SC => new { SC.CrsId, SC.StdId });

            builder.HasOne(SC => SC.Student)
                .WithMany(S => S.StudentCourses)
                .HasForeignKey(SC => SC.StdId);

            builder.HasOne(SC => SC.Course)
                .WithMany(C => C.CourseStudents)
                .HasForeignKey(SC => SC.CrsId);
                
           


        }
    }
}
