using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.Services.IAssetnventoryServices;
using app.EntityModel.DataTablePaginationModels;
using app.Services.PurchaseOrderServices;
using app.Services.DesignationServices;

namespace app.WebApp.Controllers.AssetManage
{
    public class AssetPurchaseOrderController : Controller
    {
        private readonly IAssetPurchaseOrderService _iAssetPurchaseOrderService;
        private readonly IAssetPurchaseOrderDetailService _iAssetPurchaseOrderDetailService;
        private readonly IAssetInventoryService _iAssetInventoryService;
        private readonly IDropdownService _iDropdownService;

        public AssetPurchaseOrderController(IAssetPurchaseOrderService iAssetPurchaseOrderService, IAssetPurchaseOrderDetailService iAssetPurchaseOrderDetailService, IDropdownService iDropdownService, IAssetInventoryService iAssetInventoryService)
        {
            _iAssetPurchaseOrderService = iAssetPurchaseOrderService;
            _iAssetPurchaseOrderDetailService = iAssetPurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
            //_inventoryService = inventoryService;
            _iAssetInventoryService = iAssetInventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddOrUpdateRecord(long assetPurchaseOrderId = 0)
        {
            AssetPurchaseOrderViewModel viewModel = new AssetPurchaseOrderViewModel();

            if (assetPurchaseOrderId == 0)
            {
                viewModel.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            }
            else
            {
                viewModel = await _iAssetPurchaseOrderService.GetAssetPurchaseOrder(assetPurchaseOrderId);
            }
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.AssetSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddOrUpdateRecord(AssetPurchaseOrderViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                if (vm.Id == 0)
                {
                    await _iAssetPurchaseOrderService.AddRecord(vm); //Adding Purchase Master
                }
                await _iAssetPurchaseOrderDetailService.AddRecord(vm); //Adding Purchase Details
            }
            //This is for Purchase Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _iAssetPurchaseOrderDetailService.UpdateAssetPurchaseDetail(vm);
            }
            return RedirectToAction(nameof(AddOrUpdateRecord), new { assetPurchaseOrderId = vm.Id });
        }

        public async Task<JsonResult> GetOrderDetailById(long id)
        {
            var model = await _iAssetPurchaseOrderDetailService.GetDetailById(id);
            return Json(model);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(long id)
        {
            var res = await _iAssetPurchaseOrderService.ConfirmAssetPurchaseOrder(id);
            return RedirectToAction(nameof(Search));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var res = await _iAssetPurchaseOrderService.DeleteAssetPurchaseOrder(id);
            return RedirectToAction(nameof(Search));
        }



        public async Task<IActionResult> DeleteDetailById(long id, AssetPurchaseOrderViewModel vm)
        {
            var res = await _iAssetPurchaseOrderDetailService.DeleteAssetPurchaseDetail(id);
            return RedirectToAction(nameof(AddOrUpdateRecord), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AssetPurchaseDetails(long id = 0)
        {
            AssetPurchaseOrderViewModel viewModel = await _iAssetPurchaseOrderService.GetAssetPurchaseOrderDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectAssetPurchaseOrder(AssetPurchaseOrderViewModel vm)
        {
            var res = await _iAssetPurchaseOrderService.RejectAssetPurchaseOrder(vm);
            return RedirectToAction(nameof(Search));
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetInventory(long id)
        {
            var res = await _iAssetInventoryService.AddAssetInventory(id);
            return RedirectToAction(nameof(Search));
        }


        // update Asset not in functional
        public async Task<JsonResult> UpdateAssetPurchaseOrder(long id)
        {
            var model = await _iAssetPurchaseOrderService.GetAssetPurchaseOrder(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssetPurchaseMaster(AssetPurchaseOrderViewModel vm)
        {
            var res = await _iAssetPurchaseOrderService.UpdateAssetPurchaseOrder(vm);
            return RedirectToAction(nameof(Search));
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<AssetPurchaseOrderSearchDto> searchDto)
        {
            var dataTable = await _iAssetPurchaseOrderService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion

    }
}

