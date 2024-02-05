﻿using app.EntityModel.AppModels.ATMAssemble;
using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services.ATMAssemble.AssembleWorkCategoryServices;
using app.Services.ATMAssemble.AssembleWorkStepItemServices;
using app.Utility;
using System;

namespace app.Services.ATMAssemble.AssembleWorkServices
{
    public class AssembleWorkService : IAssembleWorkService
    {
        private readonly IEntityRepository<AssembleWork> _iEntityRepository;
        private readonly InventoryDbContext _dbContext;
        private readonly IWorkContext _iWorkContext;
        private readonly IAssembleWorkCategoryService _iAssembleWorkCategoryService;
        public AssembleWorkService(IEntityRepository<AssembleWork> iEntityRepository, IAssembleWorkCategoryService iAssembleWorkCategoryService, InventoryDbContext dbContext, IWorkContext iWorkContext)
        {
            _iEntityRepository = iEntityRepository;
            _dbContext = dbContext;
            _iWorkContext = iWorkContext;
            _iAssembleWorkCategoryService = iAssembleWorkCategoryService;
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

            var bnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");
            DateTime baTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, bnTimeZone);
            var createdBy = _iWorkContext.GetCurrentUserAsync().Result.FullName;

            #region AssembleWorkEmployees
            List<AssembleWorkEmployee> assembleWorkEmployees = new List<AssembleWorkEmployee>();
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
            List<AssembleWorkDetail> assembleWorkDetails = new List<AssembleWorkDetail>();
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
            List<AssembleWork> assembleWorks = new List<AssembleWork>();
            for (int i = 0; i < viewModel.AssembleTarget; i++)
            {
                AssembleWork obj = new AssembleWork()
                {
                    AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId,
                    AssembleDate = viewModel.AssembleDate,
                    Description = viewModel.Description,
                    StatusId = (int)AssembleWorkStatusEnum.Draft,
                    WorkDetails = assembleWorkDetails,
                    WorkEmployees = assembleWorkEmployees,
                    CreatedOn = baTime,
                    CreatedBy = createdBy,
                    IsActive = true,

                };
                assembleWorks.Add(obj);
            }

            #endregion

            bool result = false;
            foreach (var assembleWork in assembleWorks)
            {
                var response = await _iEntityRepository.AddAsync(assembleWork);
                if (response != null) { result = true; }
            }

            return result;
        }

        public async Task<bool> UpdateRecord(AssembleWorkViewModel viewModel)
        {
            //var checkName = _iEntityRepository.AllIQueryableAsync().FirstOrDefault(f => f.Name.Trim() == viewModel.Name.Trim() && f.Id != viewModel.Id && f.IsActive == true);

            //if (checkName == null)
            //{
            var result = await _iEntityRepository.GetByIdAsync(viewModel.Id);
            //result.Name = viewModel.Name;
            result.Description = viewModel.Description;
            result.AssembleWorkCategoryId = viewModel.AssembleWorkCategoryId;
            await _iEntityRepository.UpdateAsync(result);
            return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public async Task<bool> DeleteRecord(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            result.IsActive = false;
            await _iEntityRepository.UpdateAsync(result);
            return true;
        }

        public async Task<AssembleWorkViewModel> GetRecordById(long id)
        {
            var result = await _iEntityRepository.GetByIdAsync(id);
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.Id = result.Id;
            //model.Name = result.Name;
            model.Description = result.Description;
            model.AssembleWorkCategoryId = result.AssembleWorkCategoryId;
            model.AssembleWorkCategoryName = result.AssembleWorkCategory?.Name;
            return model;
        }

        public async Task<AssembleWorkViewModel> GetAllRecord()
        {
            AssembleWorkViewModel model = new AssembleWorkViewModel();
            model.AssembleWorkList = await Task.Run(() => (from t1 in _dbContext.AssembleWork
                                                           where t1.IsActive == true
                                                           select new AssembleWorkViewModel
                                                           {
                                                               Id = t1.Id,
                                                               //Name = t1.Name,
                                                               Description = t1.Description,
                                                               AssembleWorkCategoryId = t1.AssembleWorkCategoryId,
                                                               AssembleWorkCategoryName = t1.AssembleWorkCategory.Name,
                                                           }).AsQueryable());
            return model;
        }

    }
}