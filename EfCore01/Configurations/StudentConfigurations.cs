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
    internal class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

        }
        ////{
        ////    builder.HasMany(S => S.Courses)
        ////        .WithMany(C => C.Students)
        ////        .UsingEntity(jt =>
        ////        {
        ////            jt.ToTable("StudentCourseTable");
        ////            jt.Property<int>("Grade");
        ////        });
        //}
    }
}
