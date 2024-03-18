using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class modelChangesInCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_District_DistrictId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Division_DivisionId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Upazila_UpazilaId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_DistrictId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_DivisionId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UpazilaId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpazilaId",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                schema: "dbo",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessIdNo",
                schema: "dbo",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a825644f-063b-428d-b761-77ff29c25f44");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "d6b101e9-90e1-4e8f-8aec-8f32ad68e308");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BusinessIdNo",
                schema: "dbo",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Customer",
                type: "int",
                nullable: true);

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
                name: "IX_Customer_DistrictId",
                schema: "dbo",
                table: "Customer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_DivisionId",
                schema: "dbo",
                table: "Customer",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UpazilaId",
                schema: "dbo",
                table: "Customer",
                column: "UpazilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_District_DistrictId",
                schema: "dbo",
                table: "Customer",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Division_DivisionId",
                schema: "dbo",
                table: "Customer",
                column: "DivisionId",
                principalSchema: "dbo",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Upazila_UpazilaId",
                schema: "dbo",
                table: "Customer",
                column: "UpazilaId",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id");
        }
    }
}
