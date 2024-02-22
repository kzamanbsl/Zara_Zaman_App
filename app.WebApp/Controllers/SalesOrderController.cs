using app.Services.DropdownServices;
using app.Services.InventoryServices;
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

        public SalesOrderController(ISalesOrderService isalesOrderService, ISalesOrderDetailService isalesOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _isalesOrderService = isalesOrderService;
            _isalesOrderDetailService = isalesOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }


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
            ViewBag.CustomerList = new SelectList((await _iDropdownService.CustomerSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.TermsandconditionList = new SelectList((await _iDropdownService.TermsandconditionsSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddSalesOrderAndDetail(SalesOrderViewModel vm)
        {

            if (vm.Id == 0)
            {
                await _isalesOrderService.AddSalesOrder(vm); //Adding Sales Master
            }
            await _isalesOrderDetailService.AddSalesOrderDetails(vm); //Adding Sales Details

            return RedirectToAction(nameof(AddSalesOrderAndDetail), new { salesOrderId = vm.Id });
        }

        #region Get Terms And Condition
        public async Task<JsonResult> GetTermsAndCondition(long id)
        {
            if (id != 0)
            {
                var model = await _isalesOrderService.GetSOTermsAndCondition(id);
                return Json(model);
            }
            return Json(null);
        }
        #endregion

    }
}

