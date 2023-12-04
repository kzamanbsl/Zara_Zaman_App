using app.Infrastructure;
using app.Infrastructure.Auth;

namespace app.Services.DropDownServices
{
    public class DropDownService : IDropDownService
    {
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public DropDownService(InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<IEnumerable<DropDownViewModel>> CompanyList()
        {
            var user = await _iWorkContext.GetCurrentAdminUserAsync();
            IEnumerable<DropDownViewModel> dropDownViewModels = await Task.Run(() => (from t1 in _dbContext.Company
                                                                                      select new DropDownViewModel
                                                                                      {
                                                                                          Id = t1.Id,
                                                                                          Name = t1.Name
                                                                                      }).AsQueryable());
            return dropDownViewModels;
        }
    }
}
