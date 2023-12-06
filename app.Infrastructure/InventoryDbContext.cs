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

        public virtual DbSet<Department> Department { get; set; }
<<<<<<< HEAD
        public virtual DbSet<Grade> Grade { get; set; }
=======
        public virtual DbSet<Designation> Designation { get; set; }
>>>>>>> 1a047ec59cb181f128dca383423de02d92ca7f11
    }
}
