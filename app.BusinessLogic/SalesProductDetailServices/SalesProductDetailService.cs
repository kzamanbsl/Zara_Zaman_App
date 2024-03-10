using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.SalesOrderServices;

namespace app.Services.SalesProductDetailServices
{
    public class SalesProductDetailService : ISalesProductDetailService
    {
        private readonly IEntityRepository<SalesProductDetail> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public SalesProductDetailService(IEntityRepository<SalesProductDetail> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }


        public async Task<bool> AddSalesProductDetails(SalesOrderViewModel vm)
        {
            try
            {
                for (int i = 0; i < vm.SalesOrderDetailVM.SalesQty; i++)
                {
                    SalesProductDetail salesDetail = new SalesProductDetail
                    {
                        SalesOrderDetailsId = vm.SalesOrderDetailVM.Id,
                        WarrantyFormDate = vm.SalesProductDetailVM.WarrantyFormDate,
                        WarrantyToDate = vm.SalesProductDetailVM.WarrantyToDate,
                        //IsForService = (bool)vm.SalesProductDetailVM.IsForService[i],
                        SerialNo = vm.SalesProductDetailVM.SerialNo[i],
                        ModelNo = vm.SalesProductDetailVM.ModelNo[i]
                    };
                    var res = await _iEntityRepository.AddAsync(salesDetail);
                    salesDetail.Id = res?.Id ?? 0;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
