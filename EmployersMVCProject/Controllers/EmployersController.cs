using Business.Interface;
using DataAccess.ApiDbContext;
using Entity.Domain;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployersMVCProject.Controllers
{
    public class EmployersController : Controller
    {
        private readonly IEmployerService employerService;
        public EmployersController(IEmployerService _employerService)
        {
            employerService = _employerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployersDTO addEmployerRequest)
        {
            await employerService.AddEmployer(addEmployerRequest);
            return RedirectToAction("Add");
        }
    }
}
