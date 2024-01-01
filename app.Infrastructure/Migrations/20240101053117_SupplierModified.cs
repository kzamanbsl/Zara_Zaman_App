using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class SupplierModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Country_CountryId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_District_DistrictId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Division_DivisionId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Upazila_UpazilaId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CountryId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_DistrictId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_DivisionId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_UpazilaId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DistrictId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DivisionId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpazilaId1",
                schema: "dbo",
                table: "Supplier");

            migrationBuilder.AlterColumn<int>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "926e8f7f-4735-44ea-82fa-e7858a638ab7");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "c43dd446-f860-4474-aa83-4bdc08a2a8c7");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DivisionId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DistrictId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CountryId",
                schema: "dbo",
                table: "Supplier",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId1",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId1",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpazilaId1",
                schema: "dbo",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "23c535cc-4ea0-4a61-aa2d-ffa3b7e0fbba");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "259f844c-39c7-458c-88ca-550682c53d99");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CountryId1",
                schema: "dbo",
                table: "Supplier",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DistrictId1",
                schema: "dbo",
                table: "Supplier",
                column: "DistrictId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_DivisionId1",
                schema: "dbo",
                table: "Supplier",
                column: "DivisionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UpazilaId1",
                schema: "dbo",
                table: "Supplier",
                column: "UpazilaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Country_CountryId1",
                schema: "dbo",
                table: "Supplier",
                column: "CountryId1",
                principalSchema: "dbo",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_District_DistrictId1",
                schema: "dbo",
                table: "Supplier",
                column: "DistrictId1",
                principalSchema: "dbo",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Division_DivisionId1",
                schema: "dbo",
                table: "Supplier",
                column: "DivisionId1",
                principalSchema: "dbo",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Upazila_UpazilaId1",
                schema: "dbo",
                table: "Supplier",
                column: "UpazilaId1",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id");
        }
    }
}
