using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ModifySalesOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_SalesTermsAndCondition_TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "TermsandconditionsId",
                schema: "dbo",
                table: "SalesOrder");

            migrationBuilder.AlterColumn<bool>(
                name: "IsForService",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndCondition",
                schema: "dbo",
                table: "SalesOrder",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermsAndCondition",
                schema: "dbo",
                table: "SalesOrder");

            migrationBuilder.AlterColumn<bool>(
                name: "IsForService",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<long>(
                name: "TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TermsandconditionsId",
                schema: "dbo",
                table: "SalesOrder",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "22484ac4-eb33-4a5c-bbae-e741d77d5f78");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "7264f801-bbb1-4378-bd10-019dacbcbb94");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder",
                column: "TermsAndConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_SalesTermsAndCondition_TermsAndConditionId",
                schema: "dbo",
                table: "SalesOrder",
                column: "TermsAndConditionId",
                principalSchema: "dbo",
                principalTable: "SalesTermsAndCondition",
                principalColumn: "Id");
        }
    }
}
