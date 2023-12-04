using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainMenu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItemId = table.Column<long>(type: "bigint", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MainMenu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TestItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPermissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");
        }
    }
}
