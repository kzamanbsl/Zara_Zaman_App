using app.EntityModel.DataTablePaginationModels;
using app.Services.DropdownServices;
using app.Services.EmployeeServices;
using app.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _iService;
        private readonly IDropdownService _iDropdownService;
        public EmployeeController(IEmployeeService iService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _iService.GetAllRecord();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdateRecord()
        {
            ViewBag.ManagerList = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.BloodgroupList = new SelectList((await _iDropdownService.BloodGroupSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.MaritalStatusList = new SelectList((await _iDropdownService.MaritalStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GenderList = new SelectList((await _iDropdownService.GenderSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ReligionList = new SelectList((await _iDropdownService.ReligionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DepartmentList = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DesignationList = new SelectList((await _iDropdownService.DesignationSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeCategoryList = new SelectList((await _iDropdownService.EmployeeCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.JobStatusList = new SelectList((await _iDropdownService.JobStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ServiceTypeList = new SelectList((await _iDropdownService.EmployeeServiceTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.OfficeTypeList = new SelectList((await _iDropdownService.OfficeTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ShiftList = new SelectList((await _iDropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GradeList = new SelectList((await _iDropdownService.EmployeeGradeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.CountryList = new SelectList((await _iDropdownService.CountrySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DivisionList = new SelectList((await _iDropdownService.DivisionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DistrictList = new SelectList((await _iDropdownService.DistrictSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UpazilaList = new SelectList((await _iDropdownService.UpazilaSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            EmployeeViewModel viewModel = new EmployeeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRecord(EmployeeViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Employee already exists!");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.ManagerList = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.BloodgroupList = new SelectList((await _iDropdownService.BloodGroupSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.MaritalStatusList = new SelectList((await _iDropdownService.MaritalStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GenderList = new SelectList((await _iDropdownService.GenderSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ReligionList = new SelectList((await _iDropdownService.ReligionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DepartmentList = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DesignationList = new SelectList((await _iDropdownService.DesignationSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeCategoryList = new SelectList((await _iDropdownService.EmployeeCategorySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.JobStatusList = new SelectList((await _iDropdownService.JobStatusSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ServiceTypeList = new SelectList((await _iDropdownService.EmployeeServiceTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.OfficeTypeList = new SelectList((await _iDropdownService.OfficeTypeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ShiftList = new SelectList((await _iDropdownService.ShiftSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.GradeList = new SelectList((await _iDropdownService.EmployeeGradeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.CountryList = new SelectList((await _iDropdownService.CountrySelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DivisionList = new SelectList((await _iDropdownService.DivisionSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.DistrictList = new SelectList((await _iDropdownService.DistrictSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UpazilaList = new SelectList((await _iDropdownService.UpazilaSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var result = await _iService.GetRecordById(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Same Employee Code already exists!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {            
            var result = await _iService.GetDetailsById(id);
            return View(result);
        }


        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.Departments = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Designations = new SelectList((await _iDropdownService.DesignationSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<EmployeeSearchDto> searchDto)
        {
            var dataTable = await _iService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion

    }
}
