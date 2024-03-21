using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class removeOverAllDiscountfromPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumption",
                schema: "dbo",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                schema: "dbo",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropColumn(
                name: "Discount",
                schema: "dbo",
                table: "PurchaseOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsOpening",
                schema: "dbo",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "OverallDiscount",
                schema: "dbo",
                table: "PurchaseOrder");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7127ce58-29e4-4241-bbd4-5e1761539c28");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "a236676e-46d7-4ab8-895a-9fc5028f10dd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Consumption",
                schema: "dbo",
                table: "PurchaseOrderDetail",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                schema: "dbo",
                table: "PurchaseOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                schema: "dbo",
                table: "PurchaseOrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpening",
                schema: "dbo",
                table: "PurchaseOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "OverallDiscount",
                schema: "dbo",
                table: "PurchaseOrder",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3f2cc01d-3012-4331-8fe3-21359d661080");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "07de033d-d379-47b7-b5b1-cfa07f1ad253");
        }
    }
}
