using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class AddedSupplierCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Country_CountryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_District_DistrictId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Division_DivisionId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Upazila_UpazilaId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CountryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_DistrictId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_DivisionId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_UpazilaId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpazilaId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ModelNo",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNo",
                schema: "dbo",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<long>(
                name: "SupplierCategoryId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupplierId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SupplierCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "cf0f364d-a213-40b7-ae23-691385a121e2");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "4ef2418d-c092-4afd-af7f-528767bf5235");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierCategoryId",
                schema: "dbo",
                table: "Supplier",
                column: "SupplierCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_SupplierCategory_SupplierCategoryId",
                schema: "dbo",
                table: "Supplier",
                column: "SupplierCategoryId",
                principalSchema: "dbo",
                principalTable: "SupplierCategory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_SupplierCategory_SupplierCategoryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "SupplierCategory",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupplierCategoryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BankAccountNo",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BranchName",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierCategoryId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelNo",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNo",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "53b8b6bf-ac79-4499-b8b4-e2749d20cfab");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "e326e018-eb6f-4ffa-a604-8f62224bae04");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CountryId",
                schema: "dbo",
                table: "Supplier",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DistrictId",
                schema: "dbo",
                table: "Supplier",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DivisionId",
                schema: "dbo",
                table: "Supplier",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UpazilaId",
                schema: "dbo",
                table: "Supplier",
                column: "UpazilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Country_CountryId",
                schema: "dbo",
                table: "Supplier",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_District_DistrictId",
                schema: "dbo",
                table: "Supplier",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Division_DivisionId",
                schema: "dbo",
                table: "Supplier",
                column: "DivisionId",
                principalSchema: "dbo",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Upazila_UpazilaId",
                schema: "dbo",
                table: "Supplier",
                column: "UpazilaId",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id");
        }
    }
}
