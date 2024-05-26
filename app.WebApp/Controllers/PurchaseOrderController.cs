using app.EntityModel.DataTablePaginationModels;
using app.Services.DesignationServices;
using app.Services.DropdownServices;
using app.Services.InventoryServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
using app.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _iPurchaseOrderService;
        private readonly IPurchaseOrderDetailService _iPurchaseOrderDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public PurchaseOrderController(IPurchaseOrderService iPurchaseOrderService, IPurchaseOrderDetailService iPurchaseOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _iPurchaseOrderService = iPurchaseOrderService;
            _iPurchaseOrderDetailService = iPurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
        //        ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
        //        PurchaseOrderViewModel viewModel = await _iPurchaseOrderService.GetAllRecord();
        //        return View(viewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}


        [HttpGet]
        public async Task<IActionResult> AddPurchaseOrderAndDetail(long purchaseOrderId = 0)
        {
            PurchaseOrderViewModel viewModel = new PurchaseOrderViewModel();

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
            //ViewBag.ProductList = new SelectList((await _iDropdownService.AssetSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");

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
                    await _iPurchaseOrderService.AddRecord(vm); //Adding Purchase Master
                }
                await _iPurchaseOrderDetailService.AddRecord(vm); //Adding Purchase Details
            }
            //This is for Purchase Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _iPurchaseOrderDetailService.UpdatePurchaseDetail(vm);
            }
            return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { purchaseOrderId = vm.Id });
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
            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePurchaseOrder(PurchaseOrderSearchDto model)
        {
            var res = await _iPurchaseOrderService.DeletePurchaseOrder(model.Id ?? 0);
            return RedirectToAction(nameof(Search));
        }


        //[HttpPost]
        //public async Task<IActionResult> Delete(DesignationSearchDto model)
        //{
        //    var res = await _iService.DeleteRecord(model.Id ?? 0);
        //    return RedirectToAction("Search");
        //}

        public async Task<IActionResult> DeletePurchaseOrderDetailsById(long id, PurchaseOrderViewModel vm)
        {
            var res = await _iPurchaseOrderDetailService.DeletePurchaseDetail(id);
            return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseDetails(long id = 0)
        {
            PurchaseOrderViewModel viewModel = await _iPurchaseOrderService.GetPurchaseOrderDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectPurchaseOrder(PurchaseOrderViewModel vm)
        {
            var res = await _iPurchaseOrderService.RejectPurchaseOrder(vm);
            return RedirectToAction("Search");
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory(long id)
        {
            var res = await _inventoryService.AddInventory(id);
            return RedirectToAction("Search");
        }


        public async Task<JsonResult> UpdatePurchaseOrder(long id)
        {
            var model = await _iPurchaseOrderService.GetPurchaseOrder(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePurchaseMaster(PurchaseOrderViewModel vm)
        {           
            var res = await _iPurchaseOrderService.UpdatePurchaseOrder(vm);            
            return RedirectToAction("Search");
        }

        #region Search

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(DataTablePagination<PurchaseOrderSearchDto> searchDto)
        {
            var dataTable = await _iPurchaseOrderService.SearchAsync(searchDto);
            return Json(dataTable);
        }

        #endregion

    }
}

