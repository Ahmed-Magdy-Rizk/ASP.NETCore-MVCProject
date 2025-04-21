using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO.DepartmentDTO
{
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; } // the date of creation 
        public string? Description { get; set; }
    }
}
