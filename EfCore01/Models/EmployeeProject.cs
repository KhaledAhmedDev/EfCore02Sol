using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class EmployeeProject
    {
        //[ForeignKey(nameof(EmployeeWorksOnProject))]
        //[Key]
        public int EmpId { get; set; }
        public virtual Employee EmployeeWorksOnProject { get; set; } = null!;

        public virtual Project ProjectWorksOnEmployee { get; set; } = null!;

       // [ForeignKey(nameof(ProjectWorksOnEmployee))]
        public int ProjectId { get; set; }
    }
}
