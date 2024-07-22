using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedSellertoSaleOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "SaleOrders",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1518), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1537), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1538) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1540), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1543), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1545), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1546) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1548), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1548) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1551), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1551) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1553), new DateTime(2024, 7, 21, 22, 41, 26, 566, DateTimeKind.Local).AddTicks(1554) });

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_SellerId",
                table: "SaleOrders",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_SellerId",
                table: "SaleOrders",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_SellerId",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_SellerId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "SaleOrders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4772), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4784) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4789), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4792), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4795), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4795) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4797), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4800), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4802), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4805), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4806) });
        }
    }
}
