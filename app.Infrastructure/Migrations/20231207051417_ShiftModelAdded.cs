using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ShiftModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "cbb5bd94-649e-4c25-b333-23e7393b7187");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "162df51d-acd9-4728-842a-bea282fa9384");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 7, 11, 14, 16, 231, DateTimeKind.Local).AddTicks(1882));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shift",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d96fc339-35c5-4a92-beb5-d7f7c2f0624a");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "2af52632-65d6-492b-9ed2-311a4af4b73b");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5015));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 6, 15, 46, 3, 642, DateTimeKind.Local).AddTicks(5090));
        }
    }
}
