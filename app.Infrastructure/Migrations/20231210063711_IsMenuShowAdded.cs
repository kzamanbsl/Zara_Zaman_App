using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class IsMenuShowAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5d6fc4b1-b317-46db-92d4-84a444ad8fef");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "200711a8-1d0d-489d-9274-0c5e25e54e1d");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 37, 11, 184, DateTimeKind.Local).AddTicks(8242));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 10, 12, 18, 48, 548, DateTimeKind.Local).AddTicks(1087));

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
    }
}
