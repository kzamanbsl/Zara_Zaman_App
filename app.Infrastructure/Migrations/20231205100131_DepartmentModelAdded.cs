using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class DepartmentModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestItem",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "0f04028e-587c-37ad-8b36-6dbd6a059fa10" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "0f04028e-587c-47ad-8b36-6dbd6a059fa4" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f04028e-587c-37ad-8b36-6dbd6a059fa10");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f04028e-587c-47ad-8b36-6dbd6a059fa4");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "TestItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "7ace8488-2ef8-447d-9455-d578f0b551bb", "Admin", "ADMIN" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "0d79bb0f-1e0b-4f60-b137-cdb8d2a0de8f", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prefix", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName", "UserType" },
                values: new object[,]
                {
                    { "0f04028e-587c-37ad-8b36-6dbd6a059fa10", 0, null, "616a2e8f-dc94-4576-8ec4-c9d75d1df6d9", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cus.jishan@gmail.com", true, "System Engineers", true, false, null, "CUS.JISHAN@GMAIL.COM", "CUSTOMER", "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==", "01840019826", true, null, "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J63", false, null, null, "Customer", 2 },
                    { "0f04028e-587c-47ad-8b36-6dbd6a059fa4", 0, null, "616a2e8f-dc94-4576-8ec4-c9d75d1df6d1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jishan.bd46@gmail.com", true, "System Admin", true, false, null, "JISHAN.BD46@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==", "01840019826", true, null, "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J6I", false, null, null, "administrator", 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MainMenu",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "IsActive", "Name", "OrderNo", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(741), "<i class=\"fas fa-user\"></i>", true, "User Management", 1, null, null },
                    { 2L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(757), "<i class=\"fas fa-cog\"></i>", true, "Configuration", 2, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MenuItem",
                columns: new[] { "Id", "Action", "Controller", "CreatedBy", "CreatedOn", "Icon", "IsActive", "MenuId", "Name", "OrderNo", "ShortName", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, "AddRecord", "MainMenu", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(774), "<i class=\"fas fa-user\"></i>", true, 1L, "Add Menu", 1, "Add Menu", null, null },
                    { 2L, "Index", "MainMenu", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(783), "<i class=\"fas fa-list\"></i>", true, 1L, "Main Menu List", 2, "Main Menu List", null, null },
                    { 3L, "AddRecord", "MenuItem", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(784), "<i class=\"fas fa-user\"></i>", true, 1L, "Add Menu Item", 3, "Add Menu Item", null, null },
                    { 4L, "Index", "MenuItem", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(786), "<i class=\"fas fa-list\"></i>", true, 1L, "Menu Item List", 4, "Menu Item List", null, null },
                    { 5L, "AddPermission", "UserPermission", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(787), "<i class=\"fas fa-user\"></i>", true, 1L, "Menu Permission", 5, "Menu Permission", null, null },
                    { 6L, "AddRecord", "Company", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(789), "<i class=\"fas fa-user\"></i>", true, 2L, "Add Company", 6, "Add Company", null, null },
                    { 7L, "Index", "Company", "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(790), "<i class=\"fas fa-list\"></i>", true, 2L, "Company List", 7, "Company List", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserPermissions",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "MenuItemId", "OrderNo", "UpdatedBy", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(809), true, 1L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 2L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(810), true, 2L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 3L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(812), true, 3L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 4L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(813), true, 4L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 5L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(814), true, 5L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 6L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(815), true, 6L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" },
                    { 7L, "System Admin", new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(816), true, 7L, 0, null, null, "0f04028e-587c-47ad-8b36-6dbd6a059fa4" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "0f04028e-587c-37ad-8b36-6dbd6a059fa10" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "0f04028e-587c-47ad-8b36-6dbd6a059fa4" });
        }
    }
}
