using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class AssetTransferModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_AssetAllocation_AssetAllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                schema: "dbo",
                table: "AssetInventory");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "Qty");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "AssetAllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "AllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocationDetail_AssetAllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "IX_AssetAllocationDetail_AllocationId");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "OrderNo",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "AllocationNo");

            migrationBuilder.RenameColumn(
                name: "AssetAllocationStatusId",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "StatusId");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StorehouseId",
                schema: "dbo",
                table: "AssetAllocation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c8277996-df3b-431b-aaf9-4f302029e056");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "5d7d0002-b43e-47c2-84e0-6ce08eec5c73");

            migrationBuilder.CreateIndex(
                name: "IX_AssetAllocation_StorehouseId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "StorehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "AssetAllocation",
                column: "StorehouseId",
                principalSchema: "dbo",
                principalTable: "BusinessCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_AssetAllocation_AllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "AllocationId",
                principalSchema: "dbo",
                principalTable: "AssetAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_AssetAllocation_AllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_AssetAllocation_StorehouseId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.DropColumn(
                name: "StorehouseId",
                schema: "dbo",
                table: "AssetAllocation");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Qty",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "AllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "AssetAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocationDetail_AllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                newName: "IX_AssetAllocationDetail_AssetAllocationId");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "AssetAllocationStatusId");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "AllocationNo",
                schema: "dbo",
                table: "AssetAllocation",
                newName: "OrderNo");

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                schema: "dbo",
                table: "AssetInventory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "defe5603-47e1-4cd2-a711-3b6a8d3d8df4");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "65b8a0d1-46bf-488b-b9f9-0e99b5d4bb11");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_AssetAllocation_AssetAllocationId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "AssetAllocationId",
                principalSchema: "dbo",
                principalTable: "AssetAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocationDetail_Product_ProductId",
                schema: "dbo",
                table: "AssetAllocationDetail",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
