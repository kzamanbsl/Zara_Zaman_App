using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class SalesProductTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalesQty",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssetAllocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAllocation_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesProductDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderDetailsId = table.Column<long>(type: "bigint", nullable: false),
                    WarrantyFormDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForService = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesProductDetail_SalesOrderDetails_SalesOrderDetailsId",
                        column: x => x.SalesOrderDetailsId,
                        principalSchema: "dbo",
                        principalTable: "SalesOrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetAllocationDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetAllocationId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetAllocationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetAllocationDetail_AssetAllocation_AssetAllocationId",
                        column: x => x.AssetAllocationId,
                        principalSchema: "dbo",
                        principalTable: "AssetAllocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetAllocationDetail_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetAllocationDetail_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b58cd3e5-be5d-4759-b08d-5f837886462e");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "c695d83f-e6ac-4613-8f03-0bcfae2fa307");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuId",
                schema: "dbo",
                table: "MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_ProductId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocationDetail_AssetAllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "AssetAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocationDetail_DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocationDetail_EmployeeId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProductDetail_SalesOrderDetailsId",
                schema: "dbo",
                table: "SalesProductDetail",
                column: "SalesOrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_MainMenu_MenuId",
                schema: "dbo",
                table: "MenuItem",
                column: "MenuId",
                principalSchema: "dbo",
                principalTable: "MainMenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_MainMenu_MenuId",
                schema: "dbo",
                table: "MenuItem");

            migrationBuilder.DropTable(
                name: "AssetAllocationDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesProductDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetAllocation",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuId",
                schema: "dbo",
                table: "MenuItem");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalesQty",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6de6fdd2-1469-442d-8b31-81ba9382d405");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "2d66fcf3-6e88-424e-a49b-091faea249b7");
        }
    }
}
