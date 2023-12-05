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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "02bdbd9b-639d-443b-ad94-fee846d666b8");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "785b26c9-66ab-42e6-9623-ac7731386466");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 546, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(20), "<i class=\"fas fa-plus\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(26), "<i class=\"fas fa-plus\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(29), "<i class=\"fas fa-plus\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(30), "<i class=\"fas fa-plus\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 5, 17, 29, 10, 547, DateTimeKind.Local).AddTicks(162));
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7ace8488-2ef8-447d-9455-d578f0b551bb");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "0d79bb0f-1e0b-4f60-b137-cdb8d2a0de8f");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(741));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(774), "<i class=\"fas fa-user\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(784), "<i class=\"fas fa-user\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(787), "<i class=\"fas fa-user\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "Icon" },
                values: new object[] { new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(789), "<i class=\"fas fa-user\"></i>" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(810));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 4, 15, 21, 6, 522, DateTimeKind.Local).AddTicks(816));
        }
    }
}
