using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class Employee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public int EmpId { get; set; } //By Convention not a pk

        
        

        public string? EmpName { get; set; }


        
        public string Email { get; set; }


     
        public string Password { get; set; }
        public string Phone { get; set; }



        public string UserName => Email.Split('@')[0];

        #region Manage Relationship [Employee-Department] [one:one] [P:T]
       [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }

        #endregion

        #region Employee has an address [1:1] [T:T]
        public Address EmpAddress { get; set; } = null!;

        #endregion

        #region Department has employees work on [1:m]  [M is mandatory]

        [InverseProperty(nameof(Department.Employees))]
        public Department WorkingDepartment { get; set; } = null!;

        [ForeignKey(nameof(WorkingDepartment))]
         public int DepartmentWorkingId { get; set; }

        #endregion


    }
}
