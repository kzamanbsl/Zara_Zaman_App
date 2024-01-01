using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class SupplierCustomerTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    UpazilaId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_District_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "dbo",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Upazila_UpazilaId",
                        column: x => x.UpazilaId,
                        principalSchema: "dbo",
                        principalTable: "Upazila",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpazilaId = table.Column<long>(type: "bigint", nullable: true),
                    UpazilaId1 = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<long>(type: "bigint", nullable: true),
                    DivisionId1 = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId1 = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CountryId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Country_CountryId1",
                        column: x => x.CountryId1,
                        principalSchema: "dbo",
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supplier_District_DistrictId1",
                        column: x => x.DistrictId1,
                        principalSchema: "dbo",
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supplier_Division_DivisionId1",
                        column: x => x.DivisionId1,
                        principalSchema: "dbo",
                        principalTable: "Division",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supplier_Upazila_UpazilaId1",
                        column: x => x.UpazilaId1,
                        principalSchema: "dbo",
                        principalTable: "Upazila",
                        principalColumn: "Id");
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "58a22838-950b-4929-beee-9467014d4432");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "d6374535-4786-49cf-acbb-0e40393464aa");
        }
    }
}
