using app.Services.AttendanceServices;
using app.Services.DropdownServices;
using app.Services.PurchaseOrderDetailServices;
using app.Services.PurchaseOrderServices;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> AddPurchaseOrderAndDetail(PurchaseOrderViewModel vm, PurchaseOrderDetailViewModel purchaseOrderDetail)
        {
            if (vm.Id == 0)
            {
                var purchaseOrderAdded = await _ipurchaseOrderService.AddRecord(vm);
                if (!purchaseOrderAdded)
                { 
                    return View("Purchase Order Failed");
                }
            }
            var purchaseOrderDetailAdded = await _ipurchaseOrderDetailService.AddRecord(purchaseOrderDetail);
            if (!purchaseOrderDetailAdded)
            {
                return View("Purchase Order Detail Failed");
            }

            return RedirectToAction("Index");
        }


    }
}
