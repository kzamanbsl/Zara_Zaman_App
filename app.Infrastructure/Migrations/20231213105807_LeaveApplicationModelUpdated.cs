using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class LeaveApplicationModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Shift_ShiftId1",
                schema: "dbo",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_ShiftId1",
                schema: "dbo",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "ShiftId1",
                schema: "dbo",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "LeaveApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ShiftId",
                schema: "dbo",
                table: "Attendance",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AttendanceLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceId = table.Column<long>(type: "bigint", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceLog_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "dbo",
                        principalTable: "Attendance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2b287c35-114e-4440-8f52-28262dc717ae");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "45c9e282-91ba-42dc-b5f7-0a9e1139924d");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3945));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 13, 16, 58, 6, 806, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ShiftId",
                schema: "dbo",
                table: "Attendance",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceLog_AttendanceId",
                schema: "dbo",
                table: "AttendanceLog",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Shift_ShiftId",
                schema: "dbo",
                table: "Attendance",
                column: "ShiftId",
                principalSchema: "dbo",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Shift_ShiftId",
                schema: "dbo",
                table: "Attendance");

            migrationBuilder.DropTable(
                name: "AttendanceLog",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_ShiftId",
                schema: "dbo",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                schema: "dbo",
                table: "Attendance",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ShiftId1",
                schema: "dbo",
                table: "Attendance",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "720b954f-0373-45cf-b883-aa9aca2099cc");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "295b63d6-f058-4a38-a3ec-bcfe49dcd1fc");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 12, 18, 37, 26, 867, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ShiftId1",
                schema: "dbo",
                table: "Attendance",
                column: "ShiftId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Shift_ShiftId1",
                schema: "dbo",
                table: "Attendance",
                column: "ShiftId1",
                principalSchema: "dbo",
                principalTable: "Shift",
                principalColumn: "Id");
        }
    }
}
