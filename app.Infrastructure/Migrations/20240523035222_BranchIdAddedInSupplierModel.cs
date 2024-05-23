using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class BranchIdAddedInSupplierModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BranchName",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.AddColumn<long>(
                name: "BranchId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Bank",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_BranchId",
                schema: "dbo",
                table: "Supplier",
                column: "BranchId",
                unique: true,
                filter: "[BranchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_BankBranch_BranchId",
                schema: "dbo",
                table: "Supplier",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "BankBranch",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_BankBranch_BranchId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_BranchId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "dbo",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                schema: "dbo",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Bank",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "738d835c-8705-4f65-97f6-94d3fa17e711");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "5a568d9c-8970-49bc-bcfa-fa1fe06ac323");
        }
    }
}
