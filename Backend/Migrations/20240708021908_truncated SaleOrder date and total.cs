using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class truncatedSaleOrderdateandtotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "SaleOrders",
                type: "DECIMAL(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SaleOrders",
                type: "DATETIME(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8943), new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8961), new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8964), new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8966), new DateTime(2024, 7, 7, 23, 19, 7, 582, DateTimeKind.Local).AddTicks(8967) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "SaleOrders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(7,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "SaleOrders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME(0)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8228), new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8248), new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8250), new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8253), new DateTime(2024, 7, 7, 22, 19, 40, 681, DateTimeKind.Local).AddTicks(8253) });
        }
    }
}
