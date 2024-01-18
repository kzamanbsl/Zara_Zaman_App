using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class PurchaseTypeIdAddedInPurchaseOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                schema: "dbo",
                table: "PurchaseOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseTypeId",
                schema: "dbo",
                table: "PurchaseOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AssetInventory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreTypeId = table.Column<int>(type: "int", nullable: false),
                    StorehouseId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    Consumption = table.Column<double>(type: "float", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_AssetInventory_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "dbo",
                        principalTable: "Unit",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "778ae8ae-afe3-4d2e-be00-230f4e019987");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "69859292-105f-47ff-b1d4-b3cdd34009a9");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInventory_ProductId",
                schema: "dbo",
                table: "AssetInventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInventory_UnitId",
                schema: "dbo",
                table: "AssetInventory",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetInventory",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "dbo",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropColumn(
                name: "PurchaseTypeId",
                schema: "dbo",
                table: "PurchaseOrder");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ee485b0f-94bf-4686-a30b-ccfdd26aaead");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "ba8c0108-b406-4850-a65f-357ac3ccd45d");
        }
    }
}
