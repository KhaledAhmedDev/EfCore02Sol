using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
   // [PrimaryKey(nameof(StdId),nameof(CrsId))]
    internal class StudentCourse
    {
        public Student Student { get; set; } = null!;


        //[ForeignKey(nameof(Student))]
        public int StdId { get; set; }


        public Course Course { get; set; } = null!;

       // [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }

        public int Grade { get; set; }
    }
}
