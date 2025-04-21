using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BLL.DTO.DepartmentDTO;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.BLL.Factory
{
    static public class DepartmentFactory
    {
        public static DepartmentDTO ToDepartmentDTO(this Department D)
        {
            return new DepartmentDTO
            {
                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn.Value),
            }; 
        }
        public static Department ToEntity(this CreatedDepartmentDTO createdDepartmentDTO)
        {
            return new Department
            {
                Name = createdDepartmentDTO.Name,
                Code = createdDepartmentDTO.Code,
                Description = createdDepartmentDTO.Description,
                CreatedOn = createdDepartmentDTO.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }
        public static Department ToEntity(this UpdateDepartmentDTO updateDepartmentDTO)
        {
            return new Department
            {
                Id = updateDepartmentDTO.Id,
                Name = updateDepartmentDTO.Name,
                Code = updateDepartmentDTO.Code,
                Description = updateDepartmentDTO.Description,
                CreatedOn = updateDepartmentDTO.DateOfCreation.ToDateTime(new TimeOnly()),
            };
        }
    }
}
