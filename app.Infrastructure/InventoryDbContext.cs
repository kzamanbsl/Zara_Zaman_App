using app.EntityModel.CoreModel;
using app.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using app.Infrastructure.ModelConfig;
using app.Infrastructure.SeedData;
using app.EntityModel.AppModels;

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
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
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
    }
}
