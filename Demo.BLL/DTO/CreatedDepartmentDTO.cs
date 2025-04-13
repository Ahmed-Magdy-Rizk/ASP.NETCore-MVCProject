using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO
{
    public class CreatedDepartmentDTO
    {
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public DateOnly DateOfCreation { get; set; } // the date of creation 
        public string? Description { get; set; }
    }
}
