using app.Services.AssetInventoryServices;
using app.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.ProductServices
{
    public interface IProductService
    {
        Task<bool> AddRecord(ProductViewModel vm);
        Task<bool> UpdateRecord(ProductViewModel vm);
        Task<ProductViewModel> GetRecordById(long id);
        Task<ProductViewModel> GetAllRecord();
        Task<bool> DeleteRecord(long id);
    }
}
