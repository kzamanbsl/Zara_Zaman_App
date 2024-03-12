using app.EntityModel.AppModels;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ProductServices;
using app.Services.UserServices;
using app.Utility;
using Microsoft.EntityFrameworkCore;

namespace app.Services.ShiftServices
{
    public class ShiftService : IShiftService
    {
        private readonly IEntityRepository<Shift> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        public ShiftService(IEntityRepository<Shift> iEntityRepository, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
        }

        public async Task<bool> AddRecord(ShiftViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.IsActive == true);
            if (checkName == null)
            {
                Shift com = new Shift();
                com.Name = vm.Name;
                com.StartAt = vm.StartAt;
                com.EndAt = vm.EndAt;
                var res = await _iEntityRepository.AddAsync(com);
                vm.Id = res.Id;
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateRecord(ShiftViewModel vm)
        {
            var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == vm.Name.Trim() && f.Id != vm.Id && f.IsActive == true);
            if (checkName == null)
            {
                var result = await _iEntityRepository.GetByIdAsync(vm.Id);
                result.Name = vm.Name;
                result.StartAt = vm.StartAt;
                result.EndAt = vm.EndAt;
                await _iEntityRepository.UpdateAsync(result);
                return true;
            }
            return false;
        }
        public async Task<ShiftViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            ShiftViewModel model = new ShiftViewModel();
            model.Id = result.Id;
            model.Name = result.Name;
            model.StartAt = result.StartAt;
            model.EndAt = result.EndAt;
            return model;
        }
        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }
        public async Task<ShiftViewModel> GetAllRecord()
        {
            ShiftViewModel model = new ShiftViewModel();
            model.ShiftList = await Task.Run(() => (from t1 in _dbContext.Shift
                                                    where t1.IsActive == true
                                                    select new ShiftViewModel
                                                    {
                                                        Id = t1.Id,
                                                        Name = t1.Name,
                                                        StartAt = t1.StartAt,
                                                        EndAt = t1.EndAt,
                                                    }).AsEnumerable());
            return model;
        }

        public async Task<DataTablePagination<ShiftSearchDto>> SearchAsync(DataTablePagination<ShiftSearchDto> searchDto)
        {
            var searchResult = _dbContext.Shift.Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.Name.ToLower().Contains(filter)
                    || c.StartAt.ToString().Contains(filter)
                    || c.EndAt.ToString().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = searchResult.Count();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<Shift> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new ShiftSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                Name = c.Name,
                StartAt = c.StartAt,
                EndAt = c.EndAt,
            }).ToList();

            return searchDto;
        }


    }
}
