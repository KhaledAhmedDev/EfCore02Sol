using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace EfCore01.Models
{
    internal class Employee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public int EmpId { get; set; } //By Convention not a pk

        
        

        public string? EmpName { get; set; }


        public decimal Salary { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }


     
        public string Password { get; set; }
        public string Phone { get; set; }



        public string UserName => Email.Split('@')[0];

        #region Manage Relationship [Employee-Department] [one:one] [P:T]
       [InverseProperty(nameof(Department.Manager))]
        public virtual Department? ManagedDepartment { get; set; }

        #endregion

        #region Employee has an address [1:1] [T:T]
        public Address EmpAddress { get; set; } = null!;

        #endregion

        #region Department has employees work on [1:m]  [M is mandatory]

        [InverseProperty(nameof(Department.Employees))]
        public virtual Department WorkingDepartment { get; set; } = null!;

        [ForeignKey(nameof(WorkingDepartment))]
         public int DepartmentWorkingId { get; set; }

        #endregion

        #region Employee may work on Project and Project Contains Many Employees [1:M] [M is optional]

        public virtual EmployeeProject? ProjectEmployeeWorksOn { get; set; }
        #endregion

        #region Suopervisor manage many Employees [1:M]

        public int? SupervisorId { get; set; }
        public virtual Employee? Supervisor { get; set; }


       
        #endregion

    }
}
