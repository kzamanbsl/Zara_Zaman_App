using app.Services.AssetAllocationDetailServices;
using app.Services.AssetAllocationServices;
using app.Services.AssetTransferDetailServices;
using app.Services.AssetTransferServices;
using app.Services.DropdownServices;
using app.Services.IAssetnventoryServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.WebApp.Controllers.AssetManage
{
    public class AssetTransferController : Controller
    {

        private readonly IAssetTransferService _iService;
        private readonly IAssetTransferDetailService _iDetailService;
        private readonly IDropdownService _iDropdownService;

        public AssetTransferController(IAssetTransferService iService, IAssetTransferDetailService iDetailService, IDropdownService iDropdownService)
        {
            _iService = iService;
            _iDetailService = iDetailService;
            _iDropdownService = iDropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecord()
        {
            var model = new AssetTransferViewModel();

            ViewBag.StorehouseList = new SelectList((await _iDropdownService.StorehouseSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            ViewBag.ProductList = new SelectList((await _iDropdownService.AssetSelectionList()).Select(s => new { s.Id, s.Name }), "Id", "Name");
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRecord(AssetTransferViewModel model)
        {
            if (model.Id == 0)
            {
                var res = _iService.AddRecord(model);
            }
            var detailRes = _iDetailService.AddRecord(model.Detail);

            return View(model);
        }
    }
}
