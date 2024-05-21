using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class UpdateSupplier : Migration
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
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0543b962-76e1-433d-a68b-c67da5fd0633");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "cd085047-0ec5-4ccb-a443-9a1788283dfa");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_BranchId",
                schema: "dbo",
                table: "Supplier",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_BankBranch_BranchId",
                schema: "dbo",
                table: "Supplier",
                column: "BranchId",
                principalSchema: "dbo",
                principalTable: "BankBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
