using app.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using app.Infrastructure.ModelConfig;
using app.Infrastructure.SeedData;
using app.EntityModel.AppModels;
using app.EntityModel.AppModels.AssetModels;
using app.EntityModel.AppModels.CustomerModels;
using app.EntityModel.AppModels.BankModels;
using app.EntityModel.AppModels.EmployeeModels;
using app.EntityModel.AppModels.InventoryModels;
using app.EntityModel.AppModels.ProductModels;
using app.EntityModel.AppModels.SupplierModels;
using app.EntityModel.AppModels.AddressModels;
using app.EntityModel.AppModels.ATMAssembleModels;
using app.EntityModel.AppModels.AttendanceModels;
using app.EntityModel.AppModels.LeaveModels;
using app.EntityModel.AppModels.PurchaseModels;
using app.EntityModel.AppModels.SalesModels;
using app.EntityModel.CoreModels;

namespace app.Infrastructure
{
    public class InventoryDbContext : IdentityDbContext<ApplicationUser>
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            BaseFixedData.SeedData(builder);
            base.OnModelCreating(builder);
            new BaseModelConfig().ModelBuilderConfig(builder);
        }

        public virtual DbSet<MainMenu> MainMenu { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<EmployeeCategory> EmployeeCategory { get; set; }
        public virtual DbSet<EmployeeGrade> EmployeeGrade { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BankBranch> BankBranch { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<EmployeeServiceType> EmployeeServiceType { get; set; }
        public virtual DbSet<OfficeType> OfficeType { get; set; }
        public virtual DbSet<DropdownItem> DropdownItem { get; set; }
        public virtual DbSet<LeaveBalance> LeaveBalance { get; set; }
        public virtual DbSet<LeaveCategory> LeaveCategory { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplication { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AttendanceLog> AttendanceLog { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Upazila> Upazila { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategory { get; set; }
        public virtual DbSet<BusinessCenter> BusinessCenter { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<SalesTermsAndCondition> SalesTermsAndCondition { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<AssetAllocation> AssetAllocation { get; set; }
        public virtual DbSet<AssetAllocationDetail> AssetAllocationDetail { get; set; }
        public virtual DbSet<AssetTransfer> AssetTransfer { get; set; }
        public virtual DbSet<AssetTransferDetail> AssetTransferDetail { get; set; }
        public virtual DbSet<SalesProductDetail> SalesProductDetail { get; set; }
        #region ATMAssemble
        public virtual DbSet<AssetInventory> AssetInventory { get; set; }
        public virtual DbSet<AssembleWorkCategory> AssembleWorkCategory { get; set; }
        public virtual DbSet<AssembleWorkStep> AssembleWorkStep { get; set; }
        public virtual DbSet<AssembleWorkStepItem> AssembleWorkStepItem { get; set; }
        public virtual DbSet<AssembleWork> AssembleWork { get; set; }
        public virtual DbSet<AssembleWorkEmployee> AssembleWorkEmployee { get; set; }
        public virtual DbSet<AssembleWorkDetail> AssembleWorkDetail { get; set; }


        #endregion



    }
}
