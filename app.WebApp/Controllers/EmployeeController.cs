using app.Services.DropdownServices;
using app.Services.EmployeeServices;
using app.Services.EmployeeServiceTypeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public async Task<IActionResult> AddOrUpdateRecord()
        {
            ViewBag.ManagerList = new SelectList((await _dropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.BloodgroupList = new SelectList((await _dropdownService.BloodGroupSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.MaritalStatusList = new SelectList((await _dropdownService.MaritalStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GenderList = new SelectList((await _dropdownService.GenderSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ReligionList = new SelectList((await _dropdownService.ReligionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DepartmentList = new SelectList((await _dropdownService.DepartmentSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DesignationList = new SelectList((await _dropdownService.DesignationSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeCategoryList = new SelectList((await _dropdownService.EmployeeCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.JobStatusList = new SelectList((await _dropdownService.JobStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ServiceTypeList = new SelectList((await _dropdownService.ServiceTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.OfficeTypeList = new SelectList((await _dropdownService.OfficeTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ShiftList = new SelectList((await _dropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GradeList = new SelectList((await _dropdownService.GradeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.CountryList = new SelectList((await _dropdownService.CountrySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DivisionList = new SelectList((await _dropdownService.DivisionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DistrictList = new SelectList((await _dropdownService.DistrictSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UpazilaList = new SelectList((await _dropdownService.UpazilaSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            EmployeeViewModel viewModel = new EmployeeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRecord(EmployeeViewModel viewModel)
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
