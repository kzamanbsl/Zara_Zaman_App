using app.EntityModel.CoreModel;
using app.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure.SeedData
{
    public class BaseFixedData
    {
        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN" }
           );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    PhoneNumber = "01840019826",
                    Email = "jishan.bd46@gmail.com",
                    EmailConfirmed = true,
                    FullName = "System Admin",
                    LockoutEnabled = false,
                    NormalizedEmail = "JISHAN.BD46@GMAIL.COM",
                    NormalizedUserName = "ADMINISTRATOR",
                    PasswordHash = "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==",//Ji123456
                    ConcurrencyStamp = "616a2e8f-dc94-4576-8ec4-c9d75d1df6d1",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J6I",
                    TwoFactorEnabled = false,
                    UserName = "administrator",
                    UserType = 1
                },
                new ApplicationUser
                {
                    Id = "0f04028e-587c-37ad-8b36-6dbd6a059fa10",
                    PhoneNumber = "01840019826",
                    Email = "cus.jishan@gmail.com",
                    EmailConfirmed = true,
                    FullName = "System Engineers",
                    LockoutEnabled = false,
                    NormalizedEmail = "CUS.JISHAN@GMAIL.COM",
                    NormalizedUserName = "CUSTOMER",
                    PasswordHash = "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==",//Ji123456
                    ConcurrencyStamp = "616a2e8f-dc94-4576-8ec4-c9d75d1df6d9",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J63",
                    TwoFactorEnabled = false,
                    UserName = "Customer",
                    UserType = 2
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
            //Customer
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
            },

             //Admin
             new IdentityUserRole<string>
             {
                 RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 UserId = "0f04028e-587c-37ad-8b36-6dbd6a059fa10"
             }
            );

            builder.Entity<MainMenu>().HasData(
                new MainMenu()
                {
                    Id = 1,
                    Name = "User Management",
                    OrderNo = 1,
                    Icon = "<i class=\"fas fa-user\"></i>",
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MainMenu()
                {
                    Id = 2,
                    Name = "Configuration",
                    OrderNo = 2,
                    Icon = "<i class=\"fas fa-cog\"></i>",
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            );

            builder.Entity<MenuItem>().HasData(
                new MenuItem()
                {
                    Id = 1,
                    Name = "Add Menu",
                    ShortName = "Add Menu",
                    OrderNo = 1,
                    Controller = "MainMenu",
                    Action = "AddRecord",
                    Icon = "<i class=\"fas fa-plus\"></i>",
                    MenuId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 2,
                    Name = "Main Menu List",
                    ShortName = "Main Menu List",
                    OrderNo = 2,
                    Controller = "MainMenu",
                    Action = "Index",
                    Icon = "<i class=\"fas fa-list\"></i>",
                    MenuId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 3,
                    Name = "Add Menu Item",
                    ShortName = "Add Menu Item",
                    OrderNo = 3,
                    Controller = "MenuItem",
                    Action = "AddRecord",
                    Icon = "<i class=\"fas fa-plus\"></i>",
                    MenuId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 4,
                    Name = "Menu Item List",
                    ShortName = "Menu Item List",
                    OrderNo = 4,
                    Controller = "MenuItem",
                    Action = "Index",
                    Icon = "<i class=\"fas fa-list\"></i>",
                    MenuId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 5,
                    Name = "Menu Permission",
                    ShortName = "Menu Permission",
                    OrderNo = 5,
                    Controller = "UserPermission",
                    Action = "AddPermission",
                    Icon = "<i class=\"fas fa-plus\"></i>",
                    MenuId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 6,
                    Name = "Add Company",
                    ShortName = "Add Company",
                    OrderNo = 6,
                    Controller = "Company",
                    Action = "AddRecord",
                    Icon = "<i class=\"fas fa-plus\"></i>",
                    MenuId = 2,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new MenuItem()
                {
                    Id = 7,
                    Name = "Company List",
                    ShortName = "Company List",
                    OrderNo = 7,
                    Controller = "Company",
                    Action = "Index",
                    Icon = "<i class=\"fas fa-list\"></i>",
                    MenuId = 2,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            );

            builder.Entity<UserPermissions>().HasData(
                new UserPermissions()
                {
                    Id = 1,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 1,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {
                    Id = 2,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 2,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {
                    Id = 3,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 3,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {
                    Id = 4,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 4,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {
                    Id = 5,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 5,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {   
                    Id = 6,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 6,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                },
                new UserPermissions()
                {
                    Id = 7,
                    UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                    MenuItemId = 7,
                    CreatedBy = "System Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
