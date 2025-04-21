using Demo.BLL.DTO.DepartmentDTO;

namespace Demo.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDTO departmentDTO);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO);
    }
}