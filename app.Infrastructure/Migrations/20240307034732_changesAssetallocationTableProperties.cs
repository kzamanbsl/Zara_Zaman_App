using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class changesAssetallocationTableProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_Department_DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_Employee_EmployeeId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocationDetail_DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_ProductId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "Tags",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocationDetail_EmployeeId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "IX_AssetAllocationDetail_ProductId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "AssetAllocationStatusId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "AssetAllocation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                schema: "dbo",
                table: "AssetAllocation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                schema: "dbo",
                table: "AssetAllocation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                schema: "dbo",
                table: "AssetAllocation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1fad2470-e5b3-4418-ad43-0a1c42507ace");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "ac2e8057-e704-4b8d-b41d-d48e173e52bc");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_DepartmentId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_EmployeeId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Department_DepartmentId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Employee_EmployeeId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Department_DepartmentId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Employee_EmployeeId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_DepartmentId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_EmployeeId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropColumn(
                name: "Tags",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocationDetail_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "IX_AssetAllocationDetail_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "AssetAllocationStatusId",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "Quantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                schema: "dbo",
                table: "AssetAllocation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                schema: "dbo",
                table: "AssetAllocation",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

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
                name: "IX_AssetAllocationDetail_DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_ProductId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_Department_DepartmentId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_Employee_EmployeeId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
