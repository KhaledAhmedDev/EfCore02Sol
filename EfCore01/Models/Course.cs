using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    internal class Course
    {
        public int Id { get; set; }

        public string? CName { get; set; }

        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<StudentCourse> CourseStudents { get; set; }= new HashSet<StudentCourse>();
       
    }
}
