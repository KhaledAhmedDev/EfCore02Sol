using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class Department
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public DateTime CreationDate { get; set; }

        public int Serial { get; set; }

        #region Manage Relatioship [Employee-Department] [one:one][P:T]
       // [InverseProperty(nameof(Employee.ManagedDepartment))]
       public Employee Manager { get; set; } = null!;

       // [ForeignKey(nameof(Manager))]
        public int DeptManagerId { get; set; }

        //Navigation +Id==>ManagerId
        //Navigation+Pk of principal table=> ManagerEmpId
        //Entity of Pk +Id==>EmployeeId
        //Entity of Pk +Pk name =>EmployeeEmpId



        #endregion

        #region Department has employees work on [1:m]  [M is mandatory]


        public ICollection<Employee> Employees { get; set; } = null!;

        #endregion
    }
}
