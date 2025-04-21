using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(T => T.CreatedOn).HasDefaultValueSql("GETDATE()"); // DOES'T ALLOW MODIFICATION
            builder.Property(T => T.LastModifiedOn).HasComputedColumnSql("GETDATE()"); //  ALLOW MODIFICATION
        }
    }
}
