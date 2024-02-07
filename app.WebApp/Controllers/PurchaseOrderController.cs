﻿using app.EntityModel.AppModels;
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
        private readonly IPurchaseOrderService _ipurchaseOrderService;
        private readonly IPurchaseOrderDetailService _ipurchaseOrderDetailService;
        private readonly IInventoryService _inventoryService;
        private readonly IDropdownService _iDropdownService;

        public PurchaseOrderController(IPurchaseOrderService ipurchaseOrderService, IPurchaseOrderDetailService ipurchaseOrderDetailService, IDropdownService iDropdownService, IInventoryService inventoryService)
        {
            _ipurchaseOrderService = ipurchaseOrderService;
            _ipurchaseOrderDetailService = ipurchaseOrderDetailService;
            _iDropdownService = iDropdownService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                PurchaseOrderViewModel viewModel = await _ipurchaseOrderService.GetAllRecord();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


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
                    await _ipurchaseOrderService.AddRecord(vm); //Adding Purchase Master
                }
                await _ipurchaseOrderDetailService.AddRecord(vm); //Adding Purchase Details
            }
            //This is for Purchase Details single Edit
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                await _ipurchaseOrderDetailService.UpdatePurchaseDetail(vm);
            }
            return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { purchaseOrderId = vm.Id });
        }

        public async Task<JsonResult> UpdateSinglePurchaseOrderDetails(long id)
        {
            var model = await _ipurchaseOrderService.SinglePurchaseOrderDetails(id);
            return Json(model);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmPurchaseOrder(long id)
        {
            var res = await _ipurchaseOrderService.ConfirmPurchaseOrder(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePurchaseOrder(long id)
        {
            var res = await _ipurchaseOrderService.DeletePurchaseMaster(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeletePurchaseOrderDetailsById(long id, PurchaseOrderViewModel vm)
        {
            var res = await _ipurchaseOrderDetailService.DeletePurchaseDetail(id);
            return RedirectToAction(nameof(AddPurchaseOrderAndDetail), new { id = vm.Id });
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseDetails(long id = 0)
        {
            PurchaseOrderViewModel viewModel = await _ipurchaseOrderService.GetPurchaseOrderDetails(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RejectPurchaseOrder(long id)
        {
            var res = await _ipurchaseOrderService.RejectPurchaseOrder(id);
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
            var model = await _ipurchaseOrderService.GetPurchaseOrder(id);
            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePurchaseMaster(PurchaseOrderViewModel vm)
        {           
            var res = await _ipurchaseOrderService.UpdatePurchaseOrder(vm);            
            return RedirectToAction("Index");
        }

    }
}

