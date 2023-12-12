using app.Services.DropdownServices;
using app.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _iService;
        private readonly IDropdownService _dropdownService;
        public EmployeeController(IEmployeeService iService, IDropdownService dropdownService)
        {
            _iService = iService;
            _dropdownService = dropdownService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(EmployeeViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == 2)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Name already exists!");
            return View(viewModel);
        }

    }
}
