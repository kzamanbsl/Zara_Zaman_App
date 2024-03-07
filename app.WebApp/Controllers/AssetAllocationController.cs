using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.AssetAllocationDetailServices;
using app.Services.AssetAllocationServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.Services.IAssetnventoryServices;
using app.EntityModel.DataTablePaginationModels;

namespace app.WebApp.Controllers
{
    public class AssetAllocationController : Controller
    {
        private readonly IAssetAllocationService _iAssetAllocationService;
        private readonly IAssetAllocationDetailService _iAssetAllocationDetailService;
        private readonly IAssetInventoryService _iassetInventoryService;
        private readonly IDropdownService _iDropdownService;

        public AssetAllocationController(IAssetAllocationService iAssetAllocationService, IAssetAllocationDetailService iAssetAllocationDetailService, IDropdownService iDropdownService, IAssetInventoryService iassetInventoryService)
        {
            _iAssetAllocationService = iAssetAllocationService;
            _iAssetAllocationDetailService = iAssetAllocationDetailService;
            _iDropdownService = iDropdownService;
            //_inventoryService = inventoryService;
            _iassetInventoryService = iassetInventoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.EmployeeList = new SelectList((await _iDropdownService.EmployeeSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ViewBag.DepartmentList = new SelectList((await _iDropdownService.DepartmentSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                
                AssetAllocationViewModel viewModel = await _iAssetAllocationService.GetAllRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddAssetAllocationAndDetail(long assetAllocationId = 0)
        {
            AssetAllocationViewModel viewModel = new AssetAllocationViewModel();

            if (assetAllocationId == 0)
            {
                viewModel.AssetAllocationStatusId = (int)AasetAllocationStatusEnum.Draft;
            }
            else
            {
                viewModel = await _iAssetAllocationService.GetAssetAllocation(assetAllocationId);
            }
            
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            
            

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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAssetAllocation(long id)
        {
            var res = await _iAssetAllocationService.DeleteAssetAllocation(id);
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetInventory(long id)
        {
            var res = await _iassetInventoryService.AddAssetInventory(id);
            return RedirectToAction("Index");
        }


        public async Task<JsonResult> UpdateAssetAllocation(long id)
        {
            var model = await _iAssetAllocationService.GetAssetAllocation(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssetAllocationMaster(AssetAllocationViewModel vm)
        {
            var res = await _iAssetAllocationService.UpdateAssetAllocation(vm);
            return RedirectToAction("Index");
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.Storehouses = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.Suppliers = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Search(DataTablePagination<AssetAllocationSearchDto> searchDto)
        //{
        //    var dataTable = await _iAssetAllocationService.SearchAsync(searchDto);
        //    return Json(dataTable);
        //}

        #endregion

    }
}

