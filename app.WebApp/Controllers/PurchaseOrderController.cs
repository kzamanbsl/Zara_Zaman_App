using app.Services.DropdownServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _ipurchaseOrderService;
        private readonly IPurchaseOrderDetailService _ipurchaseOrderDetailService;
        private readonly IDropdownService _iDropdownService;

        public PurchaseOrderController(IPurchaseOrderService ipurchaseOrderService, IPurchaseOrderDetailService ipurchaseOrderDetailService, IDropdownService iDropdownService)
        {
            _ipurchaseOrderService = ipurchaseOrderService;
            _ipurchaseOrderDetailService = ipurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                PurchaseOrderViewModel viewModel = await _ipurchaseOrderService.GetAllRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                //return View("Error");
                throw new Exception(ex.Message, ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddPurchaseOrderAndDetail(long purchaseOrderId = 0)
        {
            PurchaseOrderViewModel viewModel = new PurchaseOrderViewModel();

            if (purchaseOrderId == 0)
            {
                viewModel.OrderStatusId = PurchaseOrderStatusEnum.Draft;
            }
            else
            {
                viewModel = await _ipurchaseOrderService.GetPurchaseOrder(purchaseOrderId);
            }
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddPurchaseOrderAndDetail(PurchaseOrderViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                if (vm.Id == 0)
                {
                    await _ipurchaseOrderService.AddRecord(vm);
                }
                await _ipurchaseOrderDetailService.AddRecord(vm);
            }
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _ipurchaseOrderDetailService.UpdatePurchaseDetailsRecord(vm);
            }

            return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { purchaseOrderId = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePurchaseOrder(long purchaseOrderId)
        {
            PurchaseOrderViewModel viewModel = await _ipurchaseOrderService.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrderId == 0)
            {
                viewModel.OrderStatusId = PurchaseOrderStatusEnum.Draft;
            }
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View(nameof(UpdatePurchaseOrder), viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePurchaseOrder(PurchaseOrderViewModel vm)
        {
            var res = await _ipurchaseOrderService.DeleteRecord(vm);
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> UpdateSinglePurchaseOrderDetails(long id)
        {
            var model = await _ipurchaseOrderService.SinglePurchaseOrderDetails(id);
            return Json(model);
        }
    }
}
