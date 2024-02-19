using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
using app.Services.SalesOrderDetailServices;
using app.Services.SalesOrderServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _isalesOrderService;
        private readonly ISalesOrderDetailService _isalesOrderDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public SalesOrderController(ISalesOrderService isalesOrderService,ISalesOrderDetailService isalesOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _isalesOrderService = isalesOrderService;
            _isalesOrderDetailService = isalesOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
        //        ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
        //        PurchaseOrderViewModel viewModel = await _isalesOrderService.GetAllRecord();
        //        return View(viewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> AddSalesOrderAndDetail(long salesOrderId = 0)
        {
            SalesOrderViewModel viewModel = new SalesOrderViewModel();

            if (salesOrderId == 0)
            {
                viewModel.OrderStatusId = (int)PurchaseOrderStatusEnum.Draft;
            }
            else
            {
                viewModel = await _isalesOrderService.GetSalesOrder(salesOrderId);
            }
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddSalesOrderAndDetail(SalesOrderViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                if (vm.Id == 0)
                {
                    await _isalesOrderService.AddSalesOrder(vm); //Adding Sales Master
                }
                await _isalesOrderDetailService.AddSalesOrderDetails(vm); //Adding Sales Details
            }
            
            return RedirectToAction(nameof(AddSalesOrderAndDetail), new { salesOrderId = vm.Id });
        }





        //public async Task<JsonResult> UpdateSinglePurchaseOrderDetails(long id)
        //{
        //    var model = await _iPurchaseOrderDetailService.SinglePurchaseOrderDetails(id);
        //    return Json(model);
        //}


        //[HttpPost]
        //public async Task<IActionResult> ConfirmPurchaseOrder(long id)
        //{
        //    var res = await _iPurchaseOrderService.ConfirmPurchaseOrder(id);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeletePurchaseOrder(long id)
        //{
        //    var res = await _iPurchaseOrderService.DeletePurchaseOrder(id);
        //    return RedirectToAction(nameof(Index));
        //}


        //public async Task<IActionResult> DeletePurchaseOrderDetailsById(long id, PurchaseOrderViewModel vm)
        //{
        //    var res = await _iPurchaseOrderDetailService.DeletePurchaseDetail(id);
        //    return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { id = vm.Id });
        //}

        //[HttpGet]
        //public async Task<IActionResult> PurchaseDetails(long id = 0)
        //{
        //    PurchaseOrderViewModel viewModel = await _iPurchaseOrderService.GetPurchaseOrderDetails(id);
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RejectPurchaseOrder(long id)
        //{
        //    var res = await _iPurchaseOrderService.RejectPurchaseOrder(id);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddInventory(long id)
        //{
        //    var res = await _inventoryService.AddInventory(id);
        //    return RedirectToAction("Index");
        //}


        //public async Task<JsonResult> UpdatePurchaseOrder(long id)
        //{
        //    var model = await _iPurchaseOrderService.GetPurchaseOrder(id);
        //    return Json(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdatePurchaseMaster(PurchaseOrderViewModel vm)
        //{           
        //    var res = await _iPurchaseOrderService.UpdatePurchaseOrder(vm);            
        //    return RedirectToAction("Index");
        //}

    }
}

