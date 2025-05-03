using Demo.BLL.DTO.DepartmentDTO;
using Demo.BLL.DTO.EmployeeDTO;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.PL.ViewModels;
using Demo.PL.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices,
        ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            // Binding throw view's dictinary 
            // 1. viewdata
            ViewData["Message"] = "Hello from ViewData";

            // 2. viewbag
            ViewBag.Message = "Hello from ViewBag";


            if (string.IsNullOrEmpty(EmployeeSearchName))
            {
                var Employess = _employeeServices.GetAllEmployees();

                return View(Employess);

            }
            else
            {
                var Employess = _employeeServices.SearchEmployeeByName(EmployeeSearchName);
                return View();
            }
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Departments"] = _departmentService.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel EmployeeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeCreatedDto = new CreatedEmployeeDTO()
                    {
                        Name = EmployeeDTO.Name,
                        Address = EmployeeDTO.Address,
                        Age = EmployeeDTO.Age,
                        IsActive = EmployeeDTO.IsActive,
                        Email = EmployeeDTO.Email,
                        EmployeeType = EmployeeDTO.EmployeeType,
                        Gender = EmployeeDTO.Gender,
                        HiringDate = EmployeeDTO.HiringDate,
                        PhoneNumber = EmployeeDTO.PhoneNumber,
                        Salary = EmployeeDTO.Salary,
                        DepartmentId = EmployeeDTO.DepartmentId,
                    };
                    int result = _employeeServices.CreateEmployee(employeeCreatedDto);
                    if (result > 0)
                    {
                        TempData["Message"] = "Employee Created Successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = "Employee Creating Failed";
                        ModelState.AddModelError(string.Empty, "Employee can't be created !!");

                        return View(EmployeeDTO); // if Employee faild to be created return the same page but the old data
                    }
                }
                catch (Exception exception)
                {
                    // log Exception
                    if (_environment.IsDevelopment())
                    {
                        // 1. in development enviroment => Log Error in console and return the same view but with error message
                        ModelState.AddModelError(string.Empty, exception.Message);
                        //return View(departmentDTO);
                    }
                    else
                    {

                        // 2. 
                        _logger.LogError(exception.Message);
                        //return View(departmentDTO);
                    }
                }
            }
            return View(EmployeeDTO);
        }
        #endregion
        #region Details of Employee
        [HttpGet]
        public IActionResult Details(int? id) // we make id nullable to be able to check if the user provided an id or not
        {
            if (!id.HasValue) return BadRequest();
            var department = _employeeServices.GetEmployeebyId(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion
        #region Edit Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeebyId(id.Value);
            if (employee is null) return NotFound();

            var employeeDTO = new EmployeeViewModel()
            {
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            };
            //ViewData["Departments"] = _departmentService.GetAllDepartments();
            return View(employeeDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // to prevent any external part to edit the value of the id
        public IActionResult Edit([FromRoute] int? Id, EmployeeViewModel viewModel) // we make id nullable to be able to check if the user provided an id or not
        {
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                var employeeUpdatedDto = new UpdatedEmployeeDto()
                {
                    Id = Id.Value,
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    Age = viewModel.Age,
                    IsActive = viewModel.IsActive,
                    Email = viewModel.Email,
                    EmployeeType = viewModel.EmployeeType,
                    Gender = viewModel.Gender,
                    HiringDate = viewModel.HiringDate,
                    PhoneNumber = viewModel.PhoneNumber,
                    Salary = viewModel.Salary,
                };

                int result = _employeeServices.UpdateEmployee(employeeUpdatedDto);
                if (result > 0)
                {
                    return RedirectToAction((nameof(Index)));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can't be Edited !!");
                }
            }
            catch (Exception exception)
            {

                // log Exception
                if (_environment.IsDevelopment())
                {
                    // 1. in development enviroment => Log Error in console and return the same view but with error message
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                else
                {

                    // 2. 
                    _logger.LogError(exception.Message);
                }
            }
            return View(viewModel);
        }
        #endregion
        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _employeeServices.DeleteEmployee(id);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception exception)
            {

                // log Exception
                if (_environment.IsDevelopment())
                {
                    // 1. in development enviroment => Log Error in console and return the same view but with error message
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                else
                {

                    // 2. 
                    _logger.LogError(exception.Message);
                    //return View(departmentDTO);
                }
            }
            return Redirect(nameof(Index));
            
        }
        #endregion

    }
}
