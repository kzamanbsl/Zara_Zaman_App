using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Infrastructure.Migrations
{
    public partial class assetTransferAndDetailUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTransfer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromStoreId = table.Column<long>(type: "bigint", nullable: false),
                    ToStoreId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTransfer_BusinessCenter_FromStoreId",
                        column: x => x.FromStoreId,
                        principalSchema: "dbo",
                        principalTable: "BusinessCenter",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_AssetTransfer_BusinessCenter_ToStoreId",
                        column: x => x.ToStoreId,
                        principalSchema: "dbo",
                        principalTable: "BusinessCenter",
                        principalColumn: "Id"
                        //onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateTable(
                name: "AssetTransferDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTransferDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTransferDetail_AssetTransfer_TransferId",
                        column: x => x.TransferId,
                        principalSchema: "dbo",
                        principalTable: "AssetTransfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTransferDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c8d225bb-036a-4598-846e-95b4922c0408");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "0778cf98-28db-424a-ab4e-a1276f09ccda");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfer_FromStoreId",
                schema: "dbo",
                table: "AssetTransfer",
                column: "FromStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransfer_ToStoreId",
                schema: "dbo",
                table: "AssetTransfer",
                column: "ToStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransferDetail_ProductId",
                schema: "dbo",
                table: "AssetTransferDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransferDetail_TransferId",
                schema: "dbo",
                table: "AssetTransferDetail",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetTransferDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AssetTransfer",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c8277996-df3b-431b-aaf9-4f302029e056");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "5d7d0002-b43e-47c2-84e0-6ce08eec5c73");
        }
    }
}
