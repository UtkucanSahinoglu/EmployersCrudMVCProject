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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employers = await employerService.GetEmployer();
            return View(employers);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployersDTO addEmployerRequest)
        {
            await employerService.AddEmployer(addEmployerRequest);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var FindById = await employerService.UpdateByEmployerId(id);
            return RedirectToAction("Index");
        }
    }
}
