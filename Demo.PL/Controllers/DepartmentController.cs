using Demo.BLL.DTO.DepartmentDTO;
using Demo.BLL.Services.Interfaces;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,
        ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        //private readonly IDepartmentService _departmentService = departmentService;

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
        #region Create Region

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartment(departmentDTO);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created !!");
                        return View(departmentDTO); // if department faild to be created return the same page but the old data
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
            return View(departmentDTO);
        }
        #endregion

        #region Details of Department
        [HttpGet]
        public IActionResult Details(int? id) // we make id nullable to be able to check if the user provided an id or not
        {
            if (!id.HasValue) return BadRequest(); 
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id) // we make id nullable to be able to check if the user provided an id or not
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentEditViewModel = new DepartmentEditViewModel()
            { 
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation =  department.CreatedOn,
            };

            return View(departmentEditViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // to prevent any external part to edit the value of the id
        public IActionResult Edit([FromRoute] int? Id, DepartmentEditViewModel departmentEditViewModel) // we make id nullable to be able to check if the user provided an id or not
        {
            if (!ModelState.IsValid) return View(departmentEditViewModel);

            try
            {
                var updatedDepartment = new UpdateDepartmentDTO()
                { 
                    Id = Id.Value,
                    Code= departmentEditViewModel.Code,
                    Name = departmentEditViewModel.Name,
                    Description = departmentEditViewModel.Description,
                    DateOfCreation = departmentEditViewModel.DateOfCreation,
                };
                int result = _departmentService.UpdateDepartment(updatedDepartment);
                if (result > 0)
                {
                    return RedirectToAction((nameof(Index)));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department can't be Edited !!");
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
            return View(departmentEditViewModel);
        }
        #endregion

        #region Delete
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var depratment = _departmentService.GetDepartmentById(id.Value);

        //    if (depratment is null)
        //    {
        //        return NotFound();
        //    }
        //    return View(depratment);
        //}
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _departmentService.DeleteDepartment(id);
                if(deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not deleted");
                    return RedirectToAction(nameof(Delete), new {id});
                }
            }
            catch (Exception exception)
            {

                // log Exception
                if (_environment.IsDevelopment())
                {
                    // 1. in development enviroment => Log Error in console and return the same view but with error message
                    ModelState.AddModelError(string.Empty, exception.Message);
                    return Redirect(nameof(Index));
                }
                else
                {

                    // 2. 
                    _logger.LogError(exception.Message);
                    //return View(departmentDTO);
                }
            }
            var depratment = _departmentService.GetDepartmentById(id);

            if (depratment is null ) return NotFound();
            return View("Error");
        }
        #endregion
    }
}
