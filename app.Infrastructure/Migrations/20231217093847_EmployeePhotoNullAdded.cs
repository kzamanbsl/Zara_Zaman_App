using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class EmployeePhotoNullAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PermanentDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6aa7912c-2cb9-4c9f-a810-cd1c3249dcc5");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "72693f40-4ec9-4f0c-b593-127867ff00a5");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee",
                column: "UpazilaId",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "UpazilaId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PermanentDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "22b65034-0940-4919-bf74-16fbe353999b");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "316585e2-ca4c-47cd-aeda-1be41baf3fee");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee",
                column: "UpazilaId",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
