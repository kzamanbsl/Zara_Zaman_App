using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ProjectReviewAndUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropColumn(
                name: "BloodGroupName",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DesignationFlag",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DesignationName",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Division",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NationalId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "OfficeType",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Religion",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SearchText",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StrJoiningDate",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Upazila",
                schema: "dbo",
                table: "Employee",
                newName: "NationalIdNo");

            migrationBuilder.AlterColumn<string>(
                name: "StayDuringLeave",
                schema: "dbo",
                table: "LeaveApplication",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ShiftId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ServiceTypeId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ReligionId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "OfficeTypeId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MaritalTypeId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "JobStatusId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "GenderId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeOrder",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeCategoryId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DesignationId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "BloodGroupId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeGradeId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "042c434b-f6ec-4c2c-81eb-38fd2079dc90");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "f0554ea6-745e-4b81-a2db-067079a093b6");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BloodGroupId",
                schema: "dbo",
                table: "Employee",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                schema: "dbo",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationId",
                schema: "dbo",
                table: "Employee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictId",
                schema: "dbo",
                table: "Employee",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DivisionId",
                schema: "dbo",
                table: "Employee",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeCategoryId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeGradeId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                schema: "dbo",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobStatusId",
                schema: "dbo",
                table: "Employee",
                column: "JobStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                schema: "dbo",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MaritalTypeId",
                schema: "dbo",
                table: "Employee",
                column: "MaritalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OfficeTypeId",
                schema: "dbo",
                table: "Employee",
                column: "OfficeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ReligionId",
                schema: "dbo",
                table: "Employee",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ServiceTypeId",
                schema: "dbo",
                table: "Employee",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ShiftId",
                schema: "dbo",
                table: "Employee",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UpazilaId",
                schema: "dbo",
                table: "Employee",
                column: "UpazilaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Country_CountryId",
                schema: "dbo",
                table: "Employee",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Designation_DesignationId",
                schema: "dbo",
                table: "Employee",
                column: "DesignationId",
                principalSchema: "dbo",
                principalTable: "Designation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_District_DistrictId",
                schema: "dbo",
                table: "Employee",
                column: "DistrictId",
                principalSchema: "dbo",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Division_DivisionId",
                schema: "dbo",
                table: "Employee",
                column: "DivisionId",
                principalSchema: "dbo",
                principalTable: "Division",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DropdownItem_BloodGroupId",
                schema: "dbo",
                table: "Employee",
                column: "BloodGroupId",
                principalSchema: "dbo",
                principalTable: "DropdownItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DropdownItem_GenderId",
                schema: "dbo",
                table: "Employee",
                column: "GenderId",
                principalSchema: "dbo",
                principalTable: "DropdownItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DropdownItem_MaritalTypeId",
                schema: "dbo",
                table: "Employee",
                column: "MaritalTypeId",
                principalSchema: "dbo",
                principalTable: "DropdownItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DropdownItem_ReligionId",
                schema: "dbo",
                table: "Employee",
                column: "ReligionId",
                principalSchema: "dbo",
                principalTable: "DropdownItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                schema: "dbo",
                table: "Employee",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeCategory_EmployeeCategoryId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeCategoryId",
                principalSchema: "dbo",
                principalTable: "EmployeeCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeServiceType_ServiceTypeId",
                schema: "dbo",
                table: "Employee",
                column: "ServiceTypeId",
                principalSchema: "dbo",
                principalTable: "EmployeeServiceType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Grade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeGradeId",
                principalSchema: "dbo",
                principalTable: "Grade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobStatus_JobStatusId",
                schema: "dbo",
                table: "Employee",
                column: "JobStatusId",
                principalSchema: "dbo",
                principalTable: "JobStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_OfficeType_OfficeTypeId",
                schema: "dbo",
                table: "Employee",
                column: "OfficeTypeId",
                principalSchema: "dbo",
                principalTable: "OfficeType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Shift_ShiftId",
                schema: "dbo",
                table: "Employee",
                column: "ShiftId",
                principalSchema: "dbo",
                principalTable: "Shift",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee",
                column: "UpazilaId",
                principalSchema: "dbo",
                principalTable: "Upazila",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Country_CountryId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Designation_DesignationId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_District_DistrictId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Division_DivisionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DropdownItem_BloodGroupId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DropdownItem_GenderId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DropdownItem_MaritalTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DropdownItem_ReligionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeCategory_EmployeeCategoryId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeServiceType_ServiceTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Grade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobStatus_JobStatusId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_OfficeType_OfficeTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Shift_ShiftId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Upazila_UpazilaId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BloodGroupId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CountryId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DesignationId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistrictId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DivisionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeCategoryId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeGradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GenderId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_JobStatusId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ManagerId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_MaritalTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_OfficeTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ReligionId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ServiceTypeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ShiftId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UpazilaId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeGradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "NationalIdNo",
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
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OfficeTypeId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalTypeId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ManagerId",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobStatusId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeOrder",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeCategoryId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodGroupId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroupName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesignationFlag",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DesignationName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Division",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                schema: "dbo",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeType",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchText",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrJoiningDate",
                schema: "dbo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3c14e6a6-0280-4d6b-8c50-ce8f1d22d26a");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "5b2aac30-eb01-46ef-be50-cc83d831a0e7");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MainMenu",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedOn",
                value: new DateTime(2023, 12, 14, 18, 6, 20, 43, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplication_Employee_ManagerId",
                schema: "dbo",
                table: "LeaveApplication",
                column: "ManagerId",
                principalSchema: "dbo",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
