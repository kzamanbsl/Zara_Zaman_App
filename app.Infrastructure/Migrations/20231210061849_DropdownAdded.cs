using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class DropdownAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMenuShow",
                schema: "dbo",
                table: "MenuItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DropDownItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownItem", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "23714abd-2ce5-4006-ba65-8a5da96afea6");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "6f28944a-29e3-4df4-9d17-e4106c798da6");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1058));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1079), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1081), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1083), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1084), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1085), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1086), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedOn", "IsMenuShow" },
                values: new object[] { new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1087), true });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1110));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropDownItem",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "IsMenuShow",
                schema: "dbo",
                table: "MenuItem");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "83f8fe2d-bfd8-4235-bae8-12cc27d258d0");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "ed5d1a9a-e2dd-468d-8955-021c3b9b9297");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1627));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1675));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 10, 35, 48, 428, DateTimeKind.Local).AddTicks(1676));
        }
    }
}
