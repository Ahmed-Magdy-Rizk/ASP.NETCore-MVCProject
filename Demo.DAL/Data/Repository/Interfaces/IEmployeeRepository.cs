using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repository.Claess;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public IQueryable<Employee> GetEmployeeByName(string name);

    }
    
}
