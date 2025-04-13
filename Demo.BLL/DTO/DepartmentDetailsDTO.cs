using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.BLL.DTO
{
    public class DepartmentDetailsDTO
    {
        public DepartmentDetailsDTO(Department department)
        {

            Id = department.Id;
            Name = department.Name;
            Description = department.Description;
            Code = department.Code;
            CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value);
            CreatedBy = department.CreatedBy;
            LastModifiedBy = department.LastModifiedBy;
         
        }
        public int Id { get; set; }
        public int CreatedBy { get; set; } // the user Id who created this record
        public DateOnly CreatedOn { get; set; } // the date of creation 
        public int LastModifiedBy { get; set; } // the user Id who modfied this record
        public bool IsDeleted { get; set; } // to apply the concept of soft deleation
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
    }
}
