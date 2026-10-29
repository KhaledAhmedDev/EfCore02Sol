using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    
    internal class Address
    {
       

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Country { get; set; }

        
    }
}
