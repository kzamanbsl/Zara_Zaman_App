using app.Services.BankServices;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers.BankManagment
{
    public class BankController : Controller
    {
        public readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            var model = new BankViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddRecord(BankViewModel model)
        {
            _bankService.AddRecord(model);
            return View(model);
        }
    }
}
