using app.Services.AttendanceServices;
using app.Services.DropdownServices;
using app.Services.EmployeeServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
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


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPurchaseOrderAndDetail()
        {
            ViewBag.SupplierList = new SelectList((await _iDropdownService.SupplierSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.ProductSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.UnitList = new SelectList((await _iDropdownService.UnitSelectionList()).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            PurchaseOrderViewModel viewModel = new PurchaseOrderViewModel();
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddPurchaseOrderAndDetail(PurchaseOrderViewModel vm)
        {
            if (vm.Id == 0)
            {
                var purchaseOrderAdded = await _ipurchaseOrderService.AddRecord(vm);
                if (!purchaseOrderAdded)
                { 
                    return View("Purchase Order Failed");
                }
                await _ipurchaseOrderDetailService.AddRecord(vm);
            }
            return RedirectToAction(nameof(AddPurchaseOrderAndDetail));
        }


    }
}
