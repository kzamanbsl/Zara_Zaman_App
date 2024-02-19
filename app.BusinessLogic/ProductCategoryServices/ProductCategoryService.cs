using app.EntityModel.AppModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Utility;

namespace app.Services.ProductCategoryServices
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IEntityRepository<ProductCategory> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public ProductCategoryService(IEntityRepository<ProductCategory> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(ProductCategoryViewModel vm)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Id == vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                ProductCategory com = new ProductCategory();
                com.Name = vm.Name;
                com.ProductCategoryTypeId = (int)ProductCategoryTypeEnum.ProductCategory;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id=res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(ProductCategoryViewModel vm)
        {

            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim());
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.ProductCategoryTypeId == (int)ProductCategoryTypeEnum.AssetCategory && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.ProductCategoryTypeId = (int)ProductCategoryTypeEnum.ProductCategory;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<ProductCategoryViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ProductCategoryViewModel model = new ProductCategoryViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.ProductCategoryTypeId = result.ProductCategoryTypeId;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<ProductCategoryViewModel> GetAllRecord()
        {
            ProductCategoryViewModel model = new ProductCategoryViewModel();
            model.ProductCategoryList = await Task.Run(() => (from t1 in _dbContext.ProductCategory
                                                                where t1.ProductCategoryTypeId == (int)ProductCategoryTypeEnum.ProductCategory 
                                                                && t1.IsActive == true
                                                                select new ProductCategoryViewModel
                                                                {
                                                                    Id = t1.Id,
                                                                    Name = t1.Name,
                                                                    ProductCategoryTypeId = t1.ProductCategoryTypeId,
                                                                }).AsEnumerable());
            return model;
        }

    }
}
