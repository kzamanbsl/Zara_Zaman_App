using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class EmployeeTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "Employee",
                newName: "EmployeeCode");

            migrationBuilder.AddColumn<string>(
                name: "StayDuringLeave",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b2f9f061-7d00-4261-990c-eab293b426ea");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "248b8675-ee82-4c53-a315-32377df3451b");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3900));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3903));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 11, 22, 57, 312, DateTimeKind.Local).AddTicks(3904));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StayDuringLeave",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.RenameColumn(
                name: "EmployeeCode",
                schema: "dbo",
                table: "Employee",
                newName: "EmployeeId");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "55879171-007f-4742-9435-fd44f3751d65");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "4d548c46-21ae-462e-afa1-8d5aa4966e85");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3188));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3213));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3238));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 10, 46, 52, 0, DateTimeKind.Local).AddTicks(3241));
        }
    }
}
