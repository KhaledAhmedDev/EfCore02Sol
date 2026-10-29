
using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
           builder
    .ToTable("DepartmentsTable", "Sales");

           builder
                .HasKey(D => D.DeptId);

           builder
                .Property(D => D.DeptId)
                .UseIdentityColumn(10, 10);


           builder
                .Property(D => D.DeptName)
                .IsRequired(true)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            //modelBuilder.Entity<Department>()
            //    .Property(D => D.CreationDate)
            //    .HasDefaultValue();

            //CLR Give for this property in app default value
            //provide Timestamp of Migration
            //Migration that create Migration Date
            //If Update Happens ,Nothing will Change

           builder
                .Property(D => D.CreationDate)
                .HasDefaultValueSql("GETDATE()");

            //Provide Default value in sql on insertion for every row
            //Call GetDate()
            //If Update Happens , It will not change



            //modelBuilder.Entity<Department>()
            //    .Property(D => D.CreationDate)
            //    .HasComputedColumnSql("GETDATE()");

            //Provide Default value in sql on insertion for every row
            //Call GetDate()
            //If Update Happens ,It will recalculate value Again

            builder
                .HasMany(D => D.Employees)
                .WithOne(E => E.WorkingDepartment)
                .HasForeignKey(E => E.DepartmentWorkingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
