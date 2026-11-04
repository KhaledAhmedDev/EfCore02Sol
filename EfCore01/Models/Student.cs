using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class Student
    {
        public int Id { get; set; }

        public string? SName { get; set; }

        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
