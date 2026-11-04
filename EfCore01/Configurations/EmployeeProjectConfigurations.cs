using EfCore01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Configurations
{
    internal class EmployeeProjectConfigurations : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.HasKey(Ep => Ep.EmpId);
            builder.HasOne(Ep => Ep.EmployeeWorksOnProject)
                .WithOne(E => E.ProjectEmployeeWorksOn)
                .HasForeignKey<EmployeeProject>(Ep => Ep.EmpId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
