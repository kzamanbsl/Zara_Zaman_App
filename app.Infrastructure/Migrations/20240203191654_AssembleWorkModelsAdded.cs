using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class AssembleWorkModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "AssembleWork",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssembleWorkCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AssembleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssembleWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssembleWork_AssembleWorkCategory_AssembleWorkCategoryId",
                        column: x => x.AssembleWorkCategoryId,
                        principalSchema: "dbo",
                        principalTable: "AssembleWorkCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssembleWorkDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssembleWorkId = table.Column<long>(type: "bigint", nullable: false),
                    AssembleWorkItemId = table.Column<long>(type: "bigint", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    AssembleWorkStepItemId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssembleWorkDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssembleWorkDetail_AssembleWork_AssembleWorkId",
                        column: x => x.AssembleWorkId,
                        principalSchema: "dbo",
                        principalTable: "AssembleWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssembleWorkDetail_AssembleWorkStepItem_AssembleWorkStepItemId",
                        column: x => x.AssembleWorkStepItemId,
                        principalSchema: "dbo",
                        principalTable: "AssembleWorkStepItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssembleWorkEmployee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssembleWorkId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssembleWorkEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssembleWorkEmployee_AssembleWork_AssembleWorkId",
                        column: x => x.AssembleWorkId,
                        principalSchema: "dbo",
                        principalTable: "AssembleWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssembleWorkEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d2bda2fd-ce5c-496d-b599-59959c18a395");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "6d028fd4-619e-46d2-83cd-6b822009727a");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWorkStepItem_AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem",
                column: "AssembleWorkStepId");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWork_AssembleWorkCategoryId",
                schema: "dbo",
                table: "AssembleWork",
                column: "AssembleWorkCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWorkDetail_AssembleWorkId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                column: "AssembleWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWorkDetail_AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                column: "AssembleWorkStepItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWorkEmployee_AssembleWorkId",
                schema: "dbo",
                table: "AssembleWorkEmployee",
                column: "AssembleWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_AssembleWorkEmployee_EmployeeId",
                schema: "dbo",
                table: "AssembleWorkEmployee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssembleWorkStepItem_AssembleWorkStep_AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem",
                column: "AssembleWorkStepId",
                principalSchema: "dbo",
                principalTable: "AssembleWorkStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssembleWorkStepItem_AssembleWorkStep_AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem");

            migrationBuilder.DropTable(
                name: "AssembleWorkDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssembleWorkEmployee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssembleWork",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_AssembleWorkStepItem_AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem");

            migrationBuilder.DropColumn(
                name: "AssembleWorkStepId",
                schema: "dbo",
                table: "AssembleWorkStepItem");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5f772d1f-5c82-4414-8850-1965134404e3");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "64c0ae67-ea18-47b0-b4c5-385f9eb3befb");
        }
    }
}
