
using EfCore01.Configurations;
using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Contexts
{
    internal class CompanyDbContext:DbContext
    {
        public CompanyDbContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyDB02;Trusted_Connection=true;TrustServerCertificate=true");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Non Clean way
            //modelBuilder.Entity<Employee>()
            //    .ToTable("EmployeesTable");

            ////modelBuilder.Entity<Employee>()
            ////    .HasKey("empId");

            ////modelBuilder.Entity<Employee>()
            ////    .HasKey(nameof(Employee.EmpId));

            //modelBuilder.Entity<Employee>()
            //    .HasKey(E => E.EmpId);  //primary key (1,1)

            //modelBuilder.Entity<Employee>()
            //    .Property(E => E.EmpId)
            //    .UseIdentityColumn(10, 10);

            ////modelBuilder.Entity<Employee>()
            ////    .Property("Name");  //throw ex


            ////modelBuilder.Entity<Employee>()
            ////    .Property<string>("Name");
            ////Ef Core will search in Employee if not found
            ////Ef Core will create it as a shadow property
            ////Shadow property : Ef Core will Create it as acolumn withour representing it in the class


            //modelBuilder.Entity<Employee>()
            //    .Property(E => E.EmpName)
            //    .IsRequired(true)
            //    .HasColumnName("EmployeeName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50);


            //modelBuilder.Entity<Employee>()
            //    .Property(E => E.Email)
            //    .IsRequired();

            //modelBuilder.Entity<Employee>()
            //    .ToTable(T => T.HasCheckConstraint("CheckAgeConstraint", "Email like '%@%.%'"));  // khaled@gmail.com

            //modelBuilder.Entity<Employee>()
            //    .Ignore(E => E.UserName);

            //modelBuilder.Entity<Employee>()
            //    .Property<DateTime>("CreationDate")
            //    .HasDefaultValueSql("GETDATE()"); 
            #endregion

            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #region Non Clean Way
            //modelBuilder.Entity<Department>()
            //    .ToTable("DepartmentsTable", "Sales");

            //modelBuilder.Entity<Department>()
            //    .HasKey(D => D.DeptId);

            //modelBuilder.Entity<Department>()
            //    .Property(D => D.DeptId)
            //    .UseIdentityColumn(10, 10);


            //modelBuilder.Entity<Department>()
            //    .Property(D => D.DeptName)
            //    .IsRequired(true)
            //    .HasColumnName("DepartmentName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50);

            ////modelBuilder.Entity<Department>()
            ////    .Property(D => D.CreationDate)
            ////    .HasDefaultValue();

            ////CLR Give for this property in app default value
            ////provide Timestamp of Migration
            ////Migration that create Migration Date
            ////If Update Happens ,Nothing will Change

            //modelBuilder.Entity<Department>()
            //    .Property(D => D.CreationDate)
            //    .HasDefaultValueSql("GETDATE()");

            ////Provide Default value in sql on insertion for every row
            ////Call GetDate()
            ////If Update Happens , It will not change



            ////modelBuilder.Entity<Department>()
            ////    .Property(D => D.CreationDate)
            ////    .HasComputedColumnSql("GETDATE()");

            ////Provide Default value in sql on insertion for every row
            ////Call GetDate()
            ////If Update Happens ,It will recalculate value Again 
            #endregion


        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
