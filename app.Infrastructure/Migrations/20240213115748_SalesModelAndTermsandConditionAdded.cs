using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class SalesModelAndTermsandConditionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "Inventory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StoreFromId",
                schema: "dbo",
                table: "AssetInventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorehouseId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    OverallDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrder_BusinessCenter_StorehouseId",
                        column: x => x.StorehouseId,
                        principalSchema: "dbo",
                        principalTable: "BusinessCenter",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    SalesQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetails_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "dbo",
                        principalTable: "Unit",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
                });

            migrationBuilder.CreateTable(
                name: "SalesTermsAndCondition",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTermsAndCondition", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "549380c6-6691-4930-9ffd-eb30ca001d8c");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "f8de955b-d102-47cd-b21a-9e29322ef935");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StorehouseId",
                schema: "dbo",
                table: "Inventory",
                column: "StorehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetInventory_StorehouseId",
                schema: "dbo",
                table: "AssetInventory",
                column: "StorehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                schema: "dbo",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_StorehouseId",
                schema: "dbo",
                table: "SalesOrder",
                column: "StorehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_ProductId",
                schema: "dbo",
                table: "SalesOrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetails_UnitId",
                schema: "dbo",
                table: "SalesOrderDetails",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetInventory_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "AssetInventory",
                column: "StorehouseId",
                principalSchema: "dbo",
                principalTable: "BusinessCenter",
                principalColumn: "Id"
                /*onDelete: ReferentialAction.Cascade*/);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "Inventory",
                column: "StorehouseId",
                principalSchema: "dbo",
                principalTable: "BusinessCenter",
                principalColumn: "Id"
                /*onDelete: ReferentialAction.Cascade*/);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetInventory_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "AssetInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_BusinessCenter_StorehouseId",
                schema: "dbo",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "SalesOrder",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesOrderDetails",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SalesTermsAndCondition",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_StorehouseId",
                schema: "dbo",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_AssetInventory_StorehouseId",
                schema: "dbo",
                table: "AssetInventory");

            migrationBuilder.DropColumn(
                name: "StoreFromId",
                schema: "dbo",
                table: "AssetInventory");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Product",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a93375bb-9f49-4e3e-9a26-e92335c759a8");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "d2180eee-1c75-4ccf-905c-32c34bba5c31");
        }
    }
}
