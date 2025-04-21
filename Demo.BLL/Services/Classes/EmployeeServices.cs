using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BLL.DTO.EmployeeDTO;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repository.Interfaces;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {
        public IEnumerable<EmployeeDTO> GetAllEmployees(bool withTracking)
        {
            var Employess = _employeeRepository.GetAll(withTracking);
            // src: IEnumerable<Employee>
            // Des: IEnumerable<EmployeeDTO>
            // actual data: Employess
            var returnedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(Employess);
            //var returnedEmployees = Employess.Select(emp => new EmployeeDTO
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //    Salary = emp.Salary,
            //    IsActive = emp.IsActive,
            //    Email = emp.Email,
            //    Gender = emp.Gender.ToString(),
            //    EmployeeType = emp.EmployeeType.ToString(),
            //});
            return returnedEmployees;
        }
        public int CreateEmployee(CreatedEmployeeDTO createdEmployee)
        {
            var Employee = _mapper.Map<CreatedEmployeeDTO, Employee>(createdEmployee);
            return _employeeRepository.Add(Employee);
        }

        public bool DeleteEmployee(int id) // apply soft delete
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            }
        }


        public EmployeeDetailsDto? GetEmployeebyId(int id)
        {
            var Employe = _employeeRepository.GetById(id);
            //if (Employe is null)
            //{
            //    return null;
            //}
            //else
            //{
            //    var returnedEmployee = new EmployeeDetailsDto
            //    {
            //        Id = Employe.Id,
            //        Name = Employe.Name,
            //        Age = Employe.Age,
            //        Email = Employe.Email,
            //        Salary = Employe.Salary,
            //        IsActive = Employe.IsActive,
            //        Gender = Employe.Gender.ToString(),
            //        EmployeeType = Employe.EmployeeType.ToString(),
            //        PhoneNumber = Employe.PhoneNumber,
            //        HiringDate = DateOnly.FromDateTime(Employe.HiringDate),
            //        CreatedBy = 1,
            //        LastModifiedBy = 1,
            //    };
            //    return returnedEmployee;
            //}
            return Employe is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(Employe);
        }

        public int UpdateEmployee(UpdatedEmployeeDto updatedEmployee)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(updatedEmployee));
        }
    }
}