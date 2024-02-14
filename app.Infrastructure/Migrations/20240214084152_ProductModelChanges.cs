using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ProductModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyFormDate",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyToDate",
                schema: "dbo",
                table: "SalesOrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasModelNo",
                schema: "dbo",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSerialNo",
                schema: "dbo",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasWarranty",
                schema: "dbo",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "dd2f0fca-603b-430c-b61b-999caf16627f");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "cbc88a7e-76a6-41a2-8b5a-12ac03266685");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelNo",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "WarrantyFormDate",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "WarrantyToDate",
                schema: "dbo",
                table: "SalesOrderDetails");

            migrationBuilder.DropColumn(
                name: "HasModelNo",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "HasSerialNo",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "HasWarranty",
                schema: "dbo",
                table: "Product");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "441aa1b5-da5e-465d-891f-29392722b4e3");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "f2106f89-7467-4f12-b918-32ff5c384d08");
        }
    }
}
