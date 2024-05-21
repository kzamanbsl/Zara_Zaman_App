using app.EntityModel.AppModels;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.SalesOrderDetailServices;
using app.Services.SalesOrderServices;
using app.Services.SalesProductDetailServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.Sales
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _isalesOrderService;
        private readonly ISalesOrderDetailService _isalesOrderDetailService;
        private readonly ISalesProductDetailService _isalesProductDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public SalesOrderController(ISalesOrderService isalesOrderService, ISalesOrderDetailService isalesOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService, ISalesProductDetailService isalesProductDetailService)
        {
            _isalesOrderService = isalesOrderService;
            _isalesOrderDetailService = isalesOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
            _isalesProductDetailService = isalesProductDetailService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {

                ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
                ViewBag.CustomerList = new SelectList((await _iDropdownService.CustomerSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
                SalesOrderViewModel viewModel = await _isalesOrderService.GetAllSalesRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
            ViewBag.CustomerList = new SelectList((await _iDropdownService.CustomerSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.TermsandconditionList = new SelectList((await _iDropdownService.TermsAndConditionsSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddSalesOrderAndDetail(SalesOrderViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                if (vm.Id == 0)
                {
                    await _isalesOrderService.AddSalesOrder(vm); //Adding Purchase Master
                }
                await _isalesOrderDetailService.AddSalesOrderDetails(vm); //Adding Purchase Details               
            }
            //This is for Purchase Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _isalesOrderDetailService.UpdateSalesDetail(vm);
            }
            return RedirectToAction(nameof(AddSalesOrderAndDetail), new { salesOrderId = vm.Id });
        }


        public async Task<JsonResult> UpdateSingleSelesOrderDetails(long id)
        {
            var model = await _isalesOrderDetailService.SingleSalesOrderDetails(id);
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSalesOrder(long id)
        {
            var res = await _isalesOrderService.DeleteSalesOrder(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSalesOrderDetailsById(long id, SalesOrderDetailViewModel vm)
        {
            var res = await _isalesOrderDetailService.DeleteSalesDetail(id);
            return RedirectToAction(nameof(AddSalesOrderAndDetail), new { id = vm.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSalesOrder(SalesOrderViewModel vm)
        {
            var res = await _isalesOrderService.UpdateSalesOrder(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetSalesOrderById(long id)
        {
            var viewData = await _isalesOrderService.SalesOrderById(id);
            return Json(viewData);
        }

        #region Get Terms And Condition

        //public async Task<JsonResult> GetTermsAndCondition(long id)
        //{
        //    if (id != 0)
        //    {
        //        var model = await _isalesOrderService.GetSOTermsAndCondition(id);
        //        return Json(model);
        //    }
        //    return Json(null);
        //}  

        #endregion

    }
}

