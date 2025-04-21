using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices) : Controller
    {
        public IActionResult Index()
        {
            var Employess = _employeeServices.GetAllEmployees();
            return View(Employess);
        }
    }
}
