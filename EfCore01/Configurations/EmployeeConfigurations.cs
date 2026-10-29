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
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
            .ToTable("EmployeesTable");

            //builder
            //    .HasKey("empId");

            //builder
            //    .HasKey(nameof(Employee.EmpId));

            builder
                .HasKey(E => E.EmpId);  //primary key (1,1)

            builder
                .Property(E => E.EmpId)
                .UseIdentityColumn(10, 10);

            //builder
            //    .Property("Name");  //throw ex


            //builder
            //    .Property<string>("Name");
            //Ef Core will search in Employee if not found
            //Ef Core will create it as a shadow property
            //Shadow property : Ef Core will Create it as acolumn withour representing it in the class


            builder
                .Property(E => E.EmpName)
                .IsRequired(true)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar")
                .HasMaxLength(50);


            builder
                .Property(E => E.Email)
                .IsRequired();

            builder
                .ToTable(T => T.HasCheckConstraint("CheckAgeConstraint", "Email like '%@%.%'"));  // khaled@gmail.com

            builder
                .Ignore(E => E.UserName);

            builder
                .Property<DateTime>("CreationDate")
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(E => E.ManagedDepartment)
                .WithOne(D => D.Manager)
                .HasForeignKey<Department>(D => D.DeptManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne<Department>()
            //    .WithOne()
            //    .HasForeignKey<Department>(D => D.DeptManagerId);


            //1-Cascade:If parent is deleted all associated children will be deleted
            //Cascade In Ef Core will be mapped to Cascade also In Db

            //2-Set Null: If Parent is deleted all associated children will be Updated In Fk Column to be null
            // In Condition : Children Fk structrure allow Null
            //Set Null In Ef Core : will be mapped to set Null also In Db


            //3-No Action:If Parent referenced by children sql server will prevent delete on it
            //No Action In Ef Core : will be mapped No Action in sql

            //4-Client Cascade:I will delete parent from RAM and all associated Children also 
            // when save in disk i will faciltate search process for parent and its children away fromn disk
            //Bulk :delete
            //Ef Core will map it to No Action in sql server



            //5-Client Set Null:I will delete Parent from RAM And all  associated Children also will be updasted in fk column to be null IN RAM
            //BUlk:Update
            //Ef Core will map it no action


            //6-Client No Action
            // i will pass to database without [Deleting-Updating] Children In RAM
            // No Action in sql server


            //7-Restrict:Prevent delete of parent if it is referenced by any child
            //from App not any request send to disk
            //ef core will map : No Action
            //prevent delete from disk if restrict cannot check



            builder.ComplexProperty(E => E.EmpAddress, address =>
            {
                address.Property(a => a.City)
                .HasColumnName("EmployeeCity");
                
                address.Property(a => a.Street)
                .HasColumnName("EmployeeStreet");
                address.Property(a => a.Country)
                .HasColumnName("EmployeeCountry");
            });


        }
    }
}
