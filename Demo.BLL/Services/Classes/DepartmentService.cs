using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.DepartmentDTO;
using Demo.BLL.Factory;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repository.Claess;
using Demo.DAL.Data.Repository.Interfaces;
using Demo.DAL.Models;

namespace Demo.BLL.Services.Classes
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        // Get All Departments 
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            // manula mapping
            /*var departmentsToReturn = departments.Select(D => new DepartmentDTO()
            {
                Id = D.Id,
                Name = D.Name,
                code = D.Code,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value),

            });
            return departmentsToReturn;*/

            // Extenstion
            return departments.Select(D => D.ToDepartmentDTO());
        }

        // Get Department by Id 
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            return department is null ? null : new DepartmentDetailsDTO(department);

        }

        // Add New Department 
        public int AddDepartment(CreatedDepartmentDTO departmentDTO)
        {
            var department = departmentDTO.ToEntity();
            return _departmentRepository.Add(department);
        }
        // Update Department 
        public int UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = updateDepartmentDTO.ToEntity();

            return _departmentRepository.Update(department);
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) { return false; }
            else
            {
                int result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;
            }

        }
    }
}
