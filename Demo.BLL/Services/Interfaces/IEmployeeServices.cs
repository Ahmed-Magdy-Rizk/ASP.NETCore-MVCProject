using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.EmployeeDTO;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeServices
    {
        // Get All Employees
        IEnumerable<EmployeeDTO> GetAllEmployees(bool withTracking = false);
        IEnumerable<EmployeeDTO> SearchEmployeeByName(string name);
        EmployeeDetailsDto? GetEmployeebyId(int id);
        int CreateEmployee(CreatedEmployeeDTO createdEmployee);
        int UpdateEmployee(UpdatedEmployeeDto updatedEmployee);
        bool DeleteEmployee(int id);

    }
}
