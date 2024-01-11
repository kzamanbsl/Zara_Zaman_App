using app.EntityModel.AppModels;
using app.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.AssetInventoryServices
{
    public class AssetInventoryViewModel : BaseViewModel
    {
        public DateTime StockDate { get; set; }
        public int StoreTypeId { get; set; }
        public long StorehouseId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long UnitId { get; set; }
        public Unit Unit { get; set; }
        public double Consumption { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<AssetInventoryViewModel> AssetInventoryList { get; set; }
    }
}
