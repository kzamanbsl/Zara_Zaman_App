﻿using app.EntityModel.AppModels;
using app.EntityModel.AppModels.ATMAssemble;
using app.EntityModel.DataTablePaginationModels;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkDetailServices;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Services.EmployeeServices;
using app.Services.ProductServices;
using app.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkService : IAssembleWorkService
    {
        private readonly IEntityRepository<AssembleWork> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IAssembleWorkCategoryService _iAssembleWorkCategoryService;
        private readonly IHttpContextAccessor _iHttpContextAccessor;
        private readonly IAssembleWorkDetailService _iAssembleWorkDetailService;
        public AssembleWorkService(IEntityRepository<AssembleWork> iEntityRepository, IAssembleWorkCategoryService iAssembleWorkCategoryService, InventoryDbContext dbContext, IWorkContext iWorkContext, IHttpContextAccessor iHttpContextAccessor, IAssembleWorkDetailService iAssembleWorkDetailService)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _iAssembleWorkCategoryService = iAssembleWorkCategoryService;
            _iHttpContextAccessor = iHttpContextAccessor;
            _iAssembleWorkDetailService = iAssembleWorkDetailService;
        }

        public async Task<bool> AddRecord(AssembleWorkViewModel viewModel)
        {
            if (viewModel == null || viewModel.AssembleTarget <= 0)
            {
                throw new Exception("Sorry, Assemble target is not found!");
            }

            if (viewModel.EmployeeIds.Length <= 0)
            {
                throw new Exception("Sorry, Technician is not found!");
            }

            List<AssembleWorkStepItemViewModel> assembleWorkItem = await Task.Run(() => (from t1 in _dbContext.AssembleWorkStepItem
                                                                                         join t2 in _dbContext.AssembleWorkStep on t1.AssembleWorkStepId equals t2.Id
                                                                                         where t2.AssembleWorkCategoryId == viewModel.AssembleWorkCategoryId && t1.IsActive == true
                                                                                         select new AssembleWorkStepItemViewModel
                                                                                         {
                                                                                             Id = t1.Id,
                                                                                             Name = t1.Name,
                                                                                             Description = t1.Description,
                                                                                             AssembleWorkStepId = t1.AssembleWorkStepId,
                                                                                             AssembleWorkStepName = t1.AssembleWorkStep.Name,
                                                                                             AssembleWorkCategoryId = t1.AssembleWorkStep.AssembleWorkCategoryId,
                                                                                             AssembleWorkCategoryName = t1.AssembleWorkStep.AssembleWorkCategory.Name,

                                                                                         }).ToList());

            if (assembleWorkItem.Count <= 0)
            {
                throw new Exception("Sorry, Assemble work item is not found!");
            }

            DateTime baTime = _iWorkContext.GetBDStandardTime();
            var createdBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;

            #region AssembleWorkEmployees
            ICollection<AssembleWorkEmployee> assembleWorkEmployees = new List<AssembleWorkEmployee>();
            List<long> empIds = viewModel.EmployeeIds.ToList();
            foreach (var empId in empIds)
            {
                AssembleWorkEmployee obj = new AssembleWorkEmployee()
                {
                    EmployeeId = empId,
                    CreatedOn = baTime,
                    CreatedBy = createdBy,
                    IsActive = true,
                };
                assembleWorkEmployees.Add(obj);
            }
            #endregion

            #region AssembleWorkDetails
            ICollection<AssembleWorkDetail> assembleWorkDetails = new List<AssembleWorkDetail>();
            foreach (var item in assembleWorkItem)
            {
                AssembleWorkDetail obj = new AssembleWorkDetail()
                {
                    AssembleWorkStepItemId = item.Id,
                    CreatedOn = baTime,
                    CreatedBy = createdBy,
                    IsActive = true,
                };
                assembleWorkDetails.Add(obj);
            }
            #endregion

            #region AssembleWorks
            ICollection<AssembleWork> assembleWorks = new List<AssembleWork>();
            for (int i = 0; i < viewModel.AssembleTarget; i++)
            {
                AssembleWork obj = new AssembleWork()
                {
                    AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId,
                    AssembleDate = viewModel.AssembleDate,
                    Description = viewModel.Description,
                    StatusId = (int)AssembleWorkStatusEnum.Confirm,
                    WorkDetails = new List<AssembleWorkDetail>(),
                    WorkEmployees = new List<AssembleWorkEmployee>(),
                    CreatedOn = baTime,
                    CreatedBy = createdBy,
                    IsActive = true,

                };

                foreach (var item in assembleWorkDetails)
                {
                    obj.WorkDetails.Add(new AssembleWorkDetail
                    {
                        AssembleWorkStepItemId = item.AssembleWorkStepItemId,
                        CreatedOn = baTime,
                        CreatedBy = createdBy,
                        IsActive = true,
                    });
                }

                foreach (var item in assembleWorkEmployees)
                {
                    obj.WorkEmployees.Add(new AssembleWorkEmployee
                    {
                        EmployeeId = item.EmployeeId,
                        CreatedOn = baTime,
                        CreatedBy = createdBy,
                        IsActive = true,
                    });
                }

                assembleWorks.Add(obj);
            }

            #endregion

            bool result = false;

            _dbContext.AssembleWork.AddRange(assembleWorks);
            result = await _dbContext.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> UpdateRecord(AssembleWorkViewModel viewModel)
        {
            DateTime baTime = _iWorkContext.GetBDStandardTime();
            var createdBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;

            if (viewModel == null) { throw new Exception("Sorry! No record found."); }

            var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);

            if (viewModel == null) { throw new Exception("Sorry! No record found."); }

            result.AssembleDate = viewModel.AssembleDate;
            result.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
            result.Description = viewModel.Description;
            result.UpdatedBy = createdBy;
            result.UpdatedOn = baTime;

            #region Assemble Work Employee Mappde
            var mapEmps = _dbContext.AssembleWorkEmployee.Where(c => c.AssembleWorkId == result.Id);
            var mapEmpIds = mapEmps.Select(c => c.EmployeeId).ToList();

            var oldMappedEmps = mapEmps.Where(c => viewModel.EmployeeIds.Contains(c.EmployeeId)).ToList();
            var upMappedEmps = mapEmps.Where(c => !viewModel.EmployeeIds.Contains(c.EmployeeId)).ToList();
            var newEmpIds = viewModel.EmployeeIds.Where(c => !mapEmpIds.Contains(c)).ToList();

            List<AssembleWorkEmployee> addableDetails = new List<AssembleWorkEmployee>();
            List<AssembleWorkEmployee> updateableDetails = new List<AssembleWorkEmployee>();


            if (newEmpIds.Count > 0)
            {
                foreach (var id in newEmpIds)
                {
                    var obj = new AssembleWorkEmployee()
                    {
                        Id = 0,
                        EmployeeId = id,
                        AssembleWorkId = result.Id,
                        CreatedBy = createdBy,
                        CreatedOn = baTime,
                        IsActive = true,
                    };
                    addableDetails.Add(obj);
                }
            }

            if (oldMappedEmps.Count > 0)
            {
                foreach (var item in oldMappedEmps)
                {
                    item.IsActive = true;
                    item.UpdatedBy = createdBy;
                    item.UpdatedOn = baTime;
                    updateableDetails.Add(item);
                }
            }

            if (upMappedEmps.Count > 0)
            {
                foreach (var item in upMappedEmps)
                {
                    item.IsActive = false;
                    item.UpdatedBy = createdBy;
                    item.UpdatedOn = baTime;
                    updateableDetails.Add(item);
                }
            }

            #endregion

            bool res = false;
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                if (addableDetails.Count > 0)
                {
                    _dbContext.AssembleWorkEmployee.AddRange(addableDetails);
                    await _dbContext.SaveChangesAsync();
                }
                if (updateableDetails.Count > 0)
                {
                    _dbContext.AssembleWorkEmployee.UpdateRange(updateableDetails);
                    await _dbContext.SaveChangesAsync();
                }
                res = await _iEntityRepository.UpdateAsync(result);
                transaction.Commit();
            }

            return res;

        }

        public async Task<AssembleWorkViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.Id = result.Id;
            model.AssembleDate = result.AssembleDate;
            model.Description = result.Description;
            model.StatusId = result.StatusId;
            model.AssembleWorkCategoryId = result.AssembleWorkCategoryId;
            model.AssembleWorkCategoryName = _dbContext.AssembleWorkCategory.FirstOrDefault(c => c.Id == result.AssembleWorkCategoryId)?.Name;
            model.EmployeeList = (from t1 in _dbContext.AssembleWorkEmployee
                                  where t1.AssembleWorkId == result.Id && t1.IsActive == true
                                  select new EmployeeViewModel
                                  {
                                      Id = t1.EmployeeId,
                                      Name = t1.Employee.Name,
                                      DesignationId = t1.Employee.DesignationId,
                                      DesignationName = t1.Employee.Designation.Name,
                                      DepartmentId = t1.Employee.DepartmentId,
                                      DepartmentName = t1.Employee.Department.Name,
                                  }).ToList();

            model.DetailList = (from t1 in _dbContext.AssembleWorkDetail
                                where t1.AssembleWorkId == result.Id && t1.IsActive == true
                                select new AssembleWorkDetailViewModel
                                {
                                    Id = t1.Id,
                                    AssembleWorkStepId = t1.AssembleWorkStepItem.AssembleWorkStepId,
                                    AssembleWorkStepName = t1.AssembleWorkStepItem.AssembleWorkStep.Name,
                                    AssembleWorkStepItemId = t1.AssembleWorkStepItemId,
                                    AssembleWorkStepItemName = t1.AssembleWorkStepItem.Name,
                                    Remarks = t1.Remarks,
                                    IsComplete = t1.IsComplete,
                                }).ToList();

            var target = model.DetailList.Count;
            model.AssembleTarget = target;
            var empIds = model.EmployeeList.Select(s => s.Id).ToArray();
            model.EmployeeIds = empIds;
            return model;
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkViewModel> GetAllRecord()
        {
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.AssembleWorkList = await Task.Run(() => (from t1 in _dbContext.AssembleWork
                                                           where t1.IsActive == true
                                                           select new AssembleWorkViewModel
                                                           {
                                                               Id = t1.Id,
                                                               AssembleDate = t1.AssembleDate,
                                                               Description = t1.Description,
                                                               AssembleWorkCategoryId = t1.AssembleWorkCategoryId,
                                                               AssembleWorkCategoryName = t1.AssembleWorkCategory.Name,
                                                               StatusId = t1.StatusId,
                                                           }).AsEnumerable());
            return model;
        }

        public async Task<AssembleWorkMainDashboardViewModel> MainDashboard()
        {
            AssembleWorkMainDashboardViewModel model = new AssembleWorkMainDashboardViewModel();
            model.MainDashboardList = await Task.Run(() => (from t1 in _dbContext.AssembleWorkCategory
                                                            where t1.IsActive == true
                                                            select new AssembleWorkMainDashboardViewModel
                                                            {
                                                                AssembleWorkCategoryId = t1.Id,
                                                                AssembleWorkCategoryName = t1.Name,
                                                                AssembleDate = DateTime.Now.Date,
                                                                EmployeeList =
                                                                (from j1 in _dbContext.AssembleWork.Where(x => x.AssembleWorkCategoryId == t1.Id && x.AssembleDate.Date == DateTime.Now.Date && x.IsActive == true)
                                                                 join j2 in _dbContext.AssembleWorkEmployee on j1.Id equals j2.AssembleWorkId into t2_Join
                                                                 from j2 in t2_Join.DefaultIfEmpty()
                                                                 select new EmployeeViewModel()
                                                                 {
                                                                     Id = j2 != null ? j2.EmployeeId : 0,
                                                                     Name = j2 != null ? j2.Employee.Name : "",
                                                                 }).ToList(),

                                                                TodayTarget = _dbContext.AssembleWork.Count(c => c.AssembleWorkCategoryId == t1.Id && c.AssembleDate.Date == DateTime.Now.Date && c.IsActive == true),
                                                                WorkCompleted = _dbContext.AssembleWork.Count(c => c.AssembleWorkCategoryId == t1.Id && c.AssembleDate.Date == DateTime.Now.Date && c.StatusId == (int)AssembleWorkStatusEnum.Complete && c.IsActive == true),
                                                                FaultQty = _dbContext.AssembleWork.Count(c => c.AssembleWorkCategoryId == t1.Id && c.AssembleDate.Date == DateTime.Now.Date && c.StatusId == (int)AssembleWorkStatusEnum.Fault && c.IsActive == true),
                                                            }).AsEnumerable());

            var mainDashboardData = model.MainDashboardList.ToList();
            if (mainDashboardData?.ToList()?.Count() > 0)
            {
                foreach (var dt in mainDashboardData)
                {
                    if (!(dt.EmployeeList?.Count > 0)) continue;
                    var empNames = dt.EmployeeList.DistinctBy(c => c.Id).Select(s => s.Name).ToList();
                    dt.EmployeesName = String.Join(", ", empNames.ToArray());
                }
            }

            model.MainDashboardList = mainDashboardData;
            model.AssembleDate = DateTime.Now.Date;
            return model;
        }

        public async Task<List<AssembleWorkViewModel>> EmployeeDashboard()
        {
            List<AssembleWorkViewModel> models = new List<AssembleWorkViewModel>();
            var currentUser = await _iWorkContext.GetCurrentUserAsync();
            var loginEmployee = await _dbContext.Employee.FirstOrDefaultAsync(c => c.UserName.Equals(currentUser.UserName));

            var dataList = await _dbContext.AssembleWork.Where(x => x.AssembleDate.Date == DateTime.Now.Date && x.IsActive == true).ToListAsync();
            if (dataList.Count <= 0)
            {
                return models;
            }

            foreach (var data in dataList)
            {
                AssembleWorkViewModel model = new AssembleWorkViewModel();
                model.Id = data.Id;
                model.AssembleDate = data.AssembleDate;
                model.Description = data.Description;
                model.StatusId = data.StatusId;
                model.AssembleWorkCategoryId = data.AssembleWorkCategoryId;
                model.AssembleWorkCategoryName = _dbContext.AssembleWorkCategory.FirstOrDefault(c => c.Id == data.AssembleWorkCategoryId)?.Name;

                model.EmployeeList = (from t1 in _dbContext.AssembleWorkEmployee
                                      where t1.AssembleWorkId == data.Id && t1.IsActive == true
                                      select new EmployeeViewModel
                                      {
                                          Id = t1.EmployeeId,
                                          Name = t1.Employee.Name,
                                          DesignationId = t1.Employee.DesignationId,
                                          DesignationName = t1.Employee.Designation.Name,
                                          DepartmentId = t1.Employee.DepartmentId,
                                          DepartmentName = t1.Employee.Department.Name,

                                      }).ToList();

                model.DetailList = (from t1 in _dbContext.AssembleWorkDetail
                                    where t1.AssembleWorkId == data.Id && t1.IsActive == true
                                    select new AssembleWorkDetailViewModel
                                    {
                                        Id = t1.Id,
                                        AssembleWorkId = t1.AssembleWorkId,
                                        AssembleWorkStepId = t1.AssembleWorkStepItem.AssembleWorkStepId,
                                        AssembleWorkStepName = t1.AssembleWorkStepItem.AssembleWorkStep.Name,
                                        AssembleWorkStepItemId = t1.AssembleWorkStepItemId,
                                        AssembleWorkStepItemName = t1.AssembleWorkStepItem.Name,
                                        Remarks = t1.Remarks,
                                        IsComplete = t1.IsComplete,

                                    }).ToList();

                models.Add(model);
            }

            List<AssembleWorkViewModel> finalModels = new List<AssembleWorkViewModel>();
            if (loginEmployee?.Id > 0)
            {

                foreach (var model in models)
                {
                    var haveEmp = model.EmployeeList.FirstOrDefault(c => c.Id == loginEmployee.Id);
                    if (haveEmp != null)
                    {
                        finalModels.Add(model);
                    }

                }
            }

            return finalModels;
        }

        public async Task<object> MakeStepItemComplete(long assembleWorkId, long assembleWorkDetailId, long assembleWorkCategoryId, long assembleWorkStepId, long assembleWorkStepItemId)
        {
            var unSuccessResult = new { IsSuccess = false, AssembleWorkId = assembleWorkId, AssembleWorkDetailId = assembleWorkDetailId, AssembleWorkCategoryId = assembleWorkCategoryId, AssembleWorkStepId = assembleWorkStepId, AssembleWorkStepItemId = assembleWorkStepItemId };

            var model = await _dbContext.AssembleWorkDetail.FirstOrDefaultAsync(x => x.Id == assembleWorkDetailId && x.AssembleWorkStepItemId == assembleWorkStepItemId && x.IsActive == true);
            if (model == null)
            {
                return unSuccessResult;
            }
            model.IsComplete = true;
            var detail = new AssembleWorkDetailViewModel()
            {
                Id = model.Id,
                AssembleWorkId = model.AssembleWorkId,
                AssembleWorkStepItemId = model.AssembleWorkStepItemId,
                IsComplete = true,
                Remarks = model.Remarks,
                IsActive = model.IsActive,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                UpdatedBy = model.UpdatedBy,
                UpdatedOn = model.UpdatedOn,
            };
            var updateResult = await _iAssembleWorkDetailService.UpdateRecord(detail);
            if (updateResult == true)
            {
                var result = new { IsSuccess = true, AssembleWorkId = assembleWorkId, AssembleWorkDetailId = assembleWorkDetailId, AssembleWorkCategoryId = assembleWorkCategoryId, AssembleWorkStepId = assembleWorkStepId, AssembleWorkStepItemId = assembleWorkStepItemId };
                return result;
            }
            return unSuccessResult;
        }

        public async Task<object> MakeStatusComplete(long assembleWorkId)
        {
            DateTime baTime = _iWorkContext.GetBDStandardTime();
            var updatedBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;
            var unSuccessResult = new { IsSuccess = false, AssembleWorkId = assembleWorkId };

            var model = await _dbContext.AssembleWork.FirstOrDefaultAsync(x => x.Id == assembleWorkId && x.IsActive == true);
            if (model == null)
            {
                return unSuccessResult;
            }

            var details = await _dbContext.AssembleWorkDetail.Where(c => c.AssembleWorkId == assembleWorkId && c.IsActive == true).ToListAsync();
            if (details.Count <= 0)
            {
                throw new Exception("Sorry, No works found!");
            }

            foreach (var detail in details)
            {
                detail.IsComplete = true;
                detail.UpdatedBy = updatedBy;
                detail.UpdatedOn = baTime;
            }
            _dbContext.AssembleWorkDetail.UpdateRange(details);
            var detailUpdateResult = await _dbContext.SaveChangesAsync() > 0;
            if (detailUpdateResult == false)
            {
                return unSuccessResult;
            }

            model.StatusId = (int)AssembleWorkStatusEnum.Complete;
            var updateResult = await _iEntityRepository.UpdateAsync(model);
            if (updateResult == true)
            {
                var result = new { IsSuccess = true, AssembleWorkId = assembleWorkId };
                return result;
            }
            return unSuccessResult;
        }

        public async Task<object> MakeStatusFault(long assembleWorkId)
        {
            var unSuccessResult = new { IsSuccess = false, AssembleWorkId = assembleWorkId };

            var model = await _dbContext.AssembleWork.FirstOrDefaultAsync(x => x.Id == assembleWorkId && x.IsActive == true);
            if (model == null)
            {
                return unSuccessResult;
            }
            model.StatusId = (int)AssembleWorkStatusEnum.Fault;
            var updateResult = await _iEntityRepository.UpdateAsync(model);
            if (updateResult == true)
            {
                var result = new { IsSuccess = true, AssembleWorkId = assembleWorkId };
                return result;
            }
            return unSuccessResult;
        }

        public async Task<DataTablePagination<AssembleWorkSearchDto>> SearchAsync(DataTablePagination<AssembleWorkSearchDto> searchDto)
        {
            var searchResult = _dbContext.AssembleWork.Include(c => c.AssembleWorkCategory).Where(c => c.IsActive == true).AsNoTracking();

            var searchModel = searchDto.SearchVm;
            var filter = searchDto?.Search?.Value?.Trim();
            if (searchModel?.AssembleWorkCategoryId is > 0)
            {
                searchResult = searchResult.Where(c => c.AssembleWorkCategoryId == searchModel.AssembleWorkCategoryId);
            }
          
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                searchResult = searchResult.Where(c =>
                    c.AssembleWorkCategory.Name.ToLower().Contains(filter)
                    || c.AssembleDate.ToString().Contains(filter)
                    || c.Description.ToLower().Contains(filter)
                );
            }

            var pageSize = searchDto.Length ?? 0;
            var skip = searchDto.Start ?? 0;

            var totalRecords = await searchResult.CountAsync();
            if (totalRecords <= 0) return searchDto;

            searchDto.RecordsTotal = totalRecords;
            searchDto.RecordsFiltered = totalRecords;
            List<AssembleWork> filteredDataList = await searchResult.OrderByDescending(c => c.Id).Skip(skip).Take(pageSize).ToListAsync();

            var sl = searchDto.Start ?? 0;
            searchDto.Data = filteredDataList.Select(c => new AssembleWorkSearchDto()
            {
                SerialNo = ++sl,
                Id = c.Id,
                AssembleWorkCategoryId = c.AssembleWorkCategoryId,
                AssembleWorkCategoryName = c.AssembleWorkCategory?.Name,
                AssembleDate = c.AssembleDate,
                Description = c.Description,
                StatusId=c.StatusId
            }).ToList();

            return searchDto;
        }

    }
}