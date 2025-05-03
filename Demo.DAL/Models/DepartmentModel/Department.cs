using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Models.DepartmentModel
{
    public class Department : BaseEntity
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }

        // One to many Relationship => One Department Has many Employees

        // Navigational property
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
