using Microsoft.AspNetCore.Mvc;

namespace EmployersMVCProject.Controllers
{
    public class EmployersController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


    }
}
