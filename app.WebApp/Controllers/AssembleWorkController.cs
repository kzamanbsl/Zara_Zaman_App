﻿using app.Services.ATMAssemble.AssembleWorkServices;
using app.Services.DropdownServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssembleWorkController : Controller
    {
        private readonly IAssembleWorkService _iService;
        private readonly IDropdownService _iDropdownService;

        public AssembleWorkController(IAssembleWorkService iService, IDropdownService iDropdownService)
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
        public async Task<IActionResult> Details(long id)
        {
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            AssembleWorkViewModel viewModel = new AssembleWorkViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(AssembleWorkViewModel viewModel)
        {
            var result = await _iService.AddRecord(viewModel);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRecord(long id)
        {
            ViewBag.AssembleWorkCategoryList = new SelectList((await _iDropdownService.AssembleWorkCategorySelectionList())
                .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.EmployeeList = new MultiSelectList((await _iDropdownService.EmployeeSelectionList())
               .Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
           // AssembleWorkViewModel viewModel = new AssembleWorkViewModel();
            var result = await _iService.GetRecordById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(AssembleWorkViewModel model)
        {
            var result = await _iService.UpdateRecord(model);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "This name is already used!");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _iService.DeleteRecord(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> LiveDashboard()
        {
            var result = await _iService.LiveDashboard();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDashboard()
        {
            var result = await _iService.EmployeeDashboard();
            //var rss = result.AssembleWorkList.ToList();
            return View(result);
        }
    }
}
