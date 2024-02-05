using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class WorkDetailModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssembleWorkDetail_AssembleWorkStepItem_AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail");

            migrationBuilder.DropColumn(
                name: "AssembleWorkItemId",
                schema: "dbo",
                table: "AssembleWorkDetail");

            migrationBuilder.AlterColumn<long>(
                name: "AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "262e23a3-6c7a-4f47-b80b-377e74f62127");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "47d0e4e1-b49f-475d-b331-d9cae66983cb");

            migrationBuilder.AddForeignKey(
                name: "FK_AssembleWorkDetail_AssembleWorkStepItem_AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                column: "AssembleWorkStepItemId",
                principalSchema: "dbo",
                principalTable: "AssembleWorkStepItem",
                principalColumn: "Id"
                //onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssembleWorkDetail_AssembleWorkStepItem_AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail");

            migrationBuilder.AlterColumn<long>(
                name: "AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssembleWorkItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "abaa96c4-9c61-43f6-9f08-76734998732a");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "12bb27dd-d363-4774-ba51-9bba2bab59c9");

            migrationBuilder.AddForeignKey(
                name: "FK_AssembleWorkDetail_AssembleWorkStepItem_AssembleWorkStepItemId",
                schema: "dbo",
                table: "AssembleWorkDetail",
                column: "AssembleWorkStepItemId",
                principalSchema: "dbo",
                principalTable: "AssembleWorkStepItem",
                principalColumn: "Id");
        }
    }
}
