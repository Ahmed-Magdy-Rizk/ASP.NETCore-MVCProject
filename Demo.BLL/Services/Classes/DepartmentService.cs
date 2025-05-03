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
    public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // Get All Departments 
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
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
            var department = _unitOfWork.DepartmentRepository.GetById(id);

            return department is null ? null : new DepartmentDetailsDTO(department);

        }

        // Add New Department 
        public int AddDepartment(CreatedDepartmentDTO departmentDTO)
        {
            var department = departmentDTO.ToEntity();
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.SaveChanges();
        }
        // Update Department 
        public int UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = updateDepartmentDTO.ToEntity();

            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.SaveChanges();
        }

        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department is null) { return false; }
            else
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                return  _unitOfWork.SaveChanges() > 0 ? true : false;
            }

        }
    }
}
