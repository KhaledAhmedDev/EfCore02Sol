using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class Project
    {
        public int Id  { get; set; }

        public string? PName { get; set; }

        public ICollection<EmployeeProject> ProjectEmployees { get; set; } = new HashSet<EmployeeProject>();

    }
}
