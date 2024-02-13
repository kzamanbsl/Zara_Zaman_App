using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Services.AssetPurchaseOrderServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssetPurchaseOrderController : Controller
    {
        private readonly IAssetPurchaseOrderService _iAssetPurchaseOrderService;
        private readonly IAssetPurchaseOrderDetailService _iAssetPurchaseOrderDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public AssetPurchaseOrderController(IAssetPurchaseOrderService iAssetPurchaseOrderService, IAssetPurchaseOrderDetailService iAssetPurchaseOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _iAssetPurchaseOrderService = iAssetPurchaseOrderService;
            _iAssetPurchaseOrderDetailService = iAssetPurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                AssetPurchaseOrderViewModel viewModel = await _iAssetPurchaseOrderService.GetAllRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddAssetPurchaseOrderAndDetail(long assetPurchaseOrderId = 0)
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
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddAssetPurchaseOrderAndDetail(AssetPurchaseOrderViewModel vm)
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
                await _iAssetPurchaseOrderDetailService.UpdatePurchaseDetail(vm);
            }
            return RedirectToAction(nameof(AddAssetPurchaseOrderAndDetail), new { assetPurchaseOrderId = vm.Id });
        }

        public async Task<JsonResult> UpdateSingleAssetPurchaseOrderDetails(long id)
        {
            var model = await _iAssetPurchaseOrderDetailService.SingleAssetPurchaseOrderDetails(id);
            return Json(model);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmAssetPurchaseOrder(long id)
        {
            var res = await _iAssetPurchaseOrderService.ConfirmAssetPurchaseOrder(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAssetPurchaseOrder(long id)
        {
            var res = await _iAssetPurchaseOrderService.DeleteAssetPurchaseOrder(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteAssetPurchaseOrderDetailsById(long id, AssetPurchaseOrderViewModel vm)
        {
            var res = await _iAssetPurchaseOrderDetailService.DeletePurchaseDetail(id);
            return RedirectToAction(nameof(AddAssetPurchaseOrderAndDetail), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseDetails(long id = 0)
        {
            AssetPurchaseOrderViewModel viewModel = await _iAssetPurchaseOrderService.GetAssetPurchaseOrderDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectAssetPurchaseOrder(long id)
        {
            var res = await _iAssetPurchaseOrderService.RejectAssetPurchaseOrder(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(long id)
        {
            var res = await _inventoryService.AddInventory(id);
            return RedirectToAction("Index");
        }


        public async Task<JsonResult> UpdateAssetPurchaseOrder(long id)
        {
            var model = await _iAssetPurchaseOrderService.GetAssetPurchaseOrder(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePurchaseMaster(AssetPurchaseOrderViewModel vm)
        {
            var res = await _iAssetPurchaseOrderService.UpdateAssetPurchaseOrder(vm);
            return RedirectToAction("Index");
        }

    }
}

