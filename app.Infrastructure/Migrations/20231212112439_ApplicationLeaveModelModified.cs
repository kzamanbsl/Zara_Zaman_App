using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ApplicationLeaveModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplication_LeaveCategory_LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplication_LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropColumn(
                name: "AppliedBy",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropColumn(
                name: "LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.RenameColumn(
                name: "UpzillaId",
                schema: "dbo",
                table: "Employee",
                newName: "UpazilaId");

            migrationBuilder.RenameColumn(
                name: "Upzilla",
                schema: "dbo",
                table: "Employee",
                newName: "Upazila");

            migrationBuilder.AlterColumn<string>(
                name: "StayDuringLeave",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "18fcf060-52e4-44ba-ae70-b859c8b0b927");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "b59672a9-cef1-4ae8-8951-361b3ab0ca45");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 17, 24, 38, 606, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplication_LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "LeaveCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplication_ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id"
                /*onDelete: ReferentialAction.Cascade*/);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplication_LeaveCategory_LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "LeaveCategoryId",
                principalSchema: "dbo",
                principalTable: "LeaveCategory",
                principalColumn: "Id"
                /*onDelete: ReferentialAction.Cascade*/);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplication_LeaveCategory_LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplication_LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplication_ManagerId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.RenameColumn(
                name: "UpazilaId",
                schema: "dbo",
                table: "Employee",
                newName: "UpzillaId");

            migrationBuilder.RenameColumn(
                name: "Upazila",
                schema: "dbo",
                table: "Employee",
                newName: "Upzilla");

            migrationBuilder.AlterColumn<string>(
                name: "StayDuringLeave",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeaveCategoryId",
                schema: "dbo",
                table: "LeaveApplication",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedBy",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
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
                value: "e7407a49-6bce-4d20-8204-664624e350af");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "786b0018-8398-4252-94b8-c2b4ac66b3de");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3469));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3477));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 15, 51, 48, 637, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplication_LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication",
                column: "LeaveCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplication_LeaveCategory_LeaveCategoryId1",
                schema: "dbo",
                table: "LeaveApplication",
                column: "LeaveCategoryId1",
                principalSchema: "dbo",
                principalTable: "LeaveCategory",
                principalColumn: "Id");
        }
    }
}
