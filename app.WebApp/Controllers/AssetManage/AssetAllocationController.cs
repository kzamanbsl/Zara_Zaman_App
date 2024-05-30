﻿using app.Services.DropdownServices;
using app.Services.AssetAllocationDetailServices;
using app.Services.AssetAllocationServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.Services.IAssetnventoryServices;
using app.EntityModel.DataTablePaginationModels;
using app.Services.DesignationServices;

namespace app.WebApp.Controllers.AssetManage
{
    public class AssetAllocationController : Controller
    {
        private readonly IAssetAllocationService _iAssetAllocationService;
        private readonly IAssetAllocationDetailService _iAssetAllocationDetailService;
        private readonly IAssetInventoryService _iAssetInventoryService;
        private readonly IDropdownService _iDropdownService;

        public AssetAllocationController(IAssetAllocationService iAssetAllocationService, IAssetAllocationDetailService iAssetAllocationDetailService, IDropdownService iDropdownService, IAssetInventoryService iAssetInventoryService)
        {
            _iAssetAllocationService = iAssetAllocationService;
            _iAssetAllocationDetailService = iAssetAllocationDetailService;
            _iDropdownService = iDropdownService;
            _iAssetInventoryService = iAssetInventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddAssetAllocationAndDetail(long assetAllocationId = 0)
        {
            AssetAllocationViewModel viewModel = new AssetAllocationViewModel();

            if (assetAllocationId == 0)
            {
                viewModel.StatusId = (int)AssetAllocationStatusEnum.Draft;
            }
            else
            {
                viewModel = await _iAssetAllocationService.GetAssetAllocation(assetAllocationId);
            }

            ViewBag.EmployeeList = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.DepartmentList = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.AssetSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetAllocationAndDetail(AssetAllocationViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                if (vm.Id == 0)
                {
                    await _iAssetAllocationService.AddRecord(vm); //Adding Allocation Master
                }
                await _iAssetAllocationDetailService.AddRecord(vm); //Adding Allocation Details
            }
            //This is for Allocation Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _iAssetAllocationDetailService.UpdateAssetAllocationDetail(vm);
            }
            return RedirectToAction(nameof(AddAssetAllocationAndDetail), new { assetAllocationId = vm.Id });
        }

        public async Task<JsonResult> UpdateSingleAssetAllocationDetails(long id)
        {
            var model = await _iAssetAllocationDetailService.SingleAssetAllocationDetails(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAssetAllocation(long id)
        {
            var res = await _iAssetAllocationService.ConfirmAssetAllocation(id);
            return RedirectToAction(nameof(Search));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAssetAllocation(AssetAllocationSearchDto model)
        {
            var res = await _iAssetAllocationService.DeleteAssetAllocation(model.Id ?? 0);
            return RedirectToAction(nameof(Search));
        }

        public async Task<IActionResult> DeleteAssetAllocationDetailsById(long id, AssetAllocationViewModel vm)
        {
            var res = await _iAssetAllocationDetailService.DeleteAssetAllocationDetail(id);
            return RedirectToAction(nameof(AddAssetAllocationAndDetail), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AssetAllocationDetails(long id = 0)
        {
            AssetAllocationViewModel viewModel = await _iAssetAllocationService.GetAssetAllocationDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectAssetAllocation(long id)
        {
            var res = await _iAssetAllocationService.RejectAssetAllocation(id);
            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetInventory(long id)
        {
            var res = await _iAssetInventoryService.AddAssetInventory(id);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public async Task<JsonResult> UpdateAssetAllocation(long id)
        {
            var model = await _iAssetAllocationService.GetAssetAllocation(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssetAllocationMaster(AssetAllocationViewModel vm)
        {
            var res = await _iAssetAllocationService.UpdateAssetAllocation(vm);
            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssetAllocation(AssetAllocationViewModel vm)
        {
            var res = await _iAssetAllocationService.UpdateAssetAllocation(vm);
            return RedirectToAction("Search");
        }

        [HttpGet]
        public async Task<JsonResult> GetAssetAllocationById(long id)
        {
            var viewData = await _iAssetAllocationService.AssetAllocationById(id);
            return Json(viewData);
        }


        #region Search
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var model = new AssetAllocationSearchDto();
            ViewBag.EmployeeList = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.DepartmentList = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssetAllocationSearchDto> searchVm)
        {
            var dataTable = await _iAssetAllocationService.SearchAsync(searchVm);
            return Json(dataTable);
        }

        #endregion
    }
}

