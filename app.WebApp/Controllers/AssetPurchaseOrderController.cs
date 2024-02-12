using app.Services.AssetPurchaseOrderServices;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.AssetPurchaseOrderDetailServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class AssetPurchaseOrderController : Controller
    {
        private readonly IAssetPurchaseOrderService _iPurchaseOrderService;
        private readonly IAssetPurchaseOrderDetailService _iPurchaseOrderDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public AssetPurchaseOrderController(IAssetPurchaseOrderService iPurchaseOrderService, IAssetPurchaseOrderDetailService iPurchaseOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _iPurchaseOrderService = iPurchaseOrderService;
            _iPurchaseOrderDetailService = iPurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                AssetPurchaseOrderViewModel viewModel = await _iPurchaseOrderService.GetAllRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddAssetPurchaseOrderAndDetail(long purchaseOrderId = 0)
        {
            AssetPurchaseOrderViewModel viewModel = new AssetPurchaseOrderViewModel();

            if (purchaseOrderId == 0)
            {
                viewModel.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            }
            else
            {
                viewModel = await _iPurchaseOrderService.GetPurchaseOrder(purchaseOrderId);
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
                    await _iPurchaseOrderService.AddRecord(vm); //Adding Purchase Master
                }
                //await _iPurchaseOrderDetailService.AddRecord(vm); //Adding Purchase Details
            }
            //This is for Purchase Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                //await _iPurchaseOrderDetailService.UpdatePurchaseDetail(vm);
            }
            return RedirectToAction(nameof(AddAssetPurchaseOrderAndDetail), new { purchaseOrderId = vm.Id });
        }

        public async Task<JsonResult> UpdateSinglePurchaseOrderDetails(long id)
        {
            var model = await _iPurchaseOrderDetailService.SinglePurchaseOrderDetails(id);
            return Json(model);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmPurchaseOrder(long id)
        {
            var res = await _iPurchaseOrderService.ConfirmPurchaseOrder(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePurchaseOrder(long id)
        {
            var res = await _iPurchaseOrderService.DeletePurchaseOrder(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeletePurchaseOrderDetailsById(long id, AssetPurchaseOrderViewModel vm)
        {
            var res = await _iPurchaseOrderDetailService.DeletePurchaseDetail(id);
            return RedirectToAction(nameof(AddAssetPurchaseOrderAndDetail), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseDetails(long id = 0)
        {
            AssetPurchaseOrderViewModel viewModel = await _iPurchaseOrderService.GetPurchaseOrderDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectPurchaseOrder(long id)
        {
            var res = await _iPurchaseOrderService.RejectPurchaseOrder(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(long id)
        {
            var res = await _inventoryService.AddInventory(id);
            return RedirectToAction("Index");
        }


        public async Task<JsonResult> UpdatePurchaseOrder(long id)
        {
            var model = await _iPurchaseOrderService.GetPurchaseOrder(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePurchaseMaster(AssetPurchaseOrderViewModel vm)
        {           
            var res = await _iPurchaseOrderService.UpdatePurchaseOrder(vm);            
            return RedirectToAction("Index");
        }

    }
}

