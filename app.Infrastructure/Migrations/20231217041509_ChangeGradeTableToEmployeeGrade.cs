using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class ChangeGradeTableToEmployeeGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Grade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                schema: "dbo",
                table: "Grade");

            migrationBuilder.RenameTable(
                name: "Grade",
                schema: "dbo",
                newName: "EmployeeGrade",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeGrade",
                schema: "dbo",
                table: "EmployeeGrade",
                column: "Id");

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
                name: "FK_Employee_EmployeeGrade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeGradeId",
                principalSchema: "dbo",
                principalTable: "EmployeeGrade",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeGrade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeGrade",
                schema: "dbo",
                table: "EmployeeGrade");

            migrationBuilder.RenameTable(
                name: "EmployeeGrade",
                schema: "dbo",
                newName: "Grade",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                schema: "dbo",
                table: "Grade",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Grade_EmployeeGradeId",
                schema: "dbo",
                table: "Employee",
                column: "EmployeeGradeId",
                principalSchema: "dbo",
                principalTable: "Grade",
                principalColumn: "Id");
        }
    }
}
