using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configurations
{
    public class EmployeeConfigurations : BaseEntityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Employee-specific configurations
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10, 2)");

            builder.Property(E => E.Gender)
                .HasConversion(
                    empGender => empGender.ToString(),
                    returnedEmpGender => (Gender)Enum.Parse(typeof(Gender), returnedEmpGender)
                );

            builder.Property(E => E.EmployeeType)
                .HasConversion(
                    empType => empType.ToString(),
                    returnedEmpType => (EmployeeType)Enum.Parse(typeof(EmployeeType), returnedEmpType)
                );

            // Apply base configurations
            base.Configure(builder);
        }
    }

}
