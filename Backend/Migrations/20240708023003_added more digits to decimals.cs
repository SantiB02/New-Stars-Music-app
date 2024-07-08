using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedmoredigitstodecimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "SaleOrders",
                type: "DECIMAL(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(7,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(9,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(7,2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3660), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3680), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3684) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3687), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3688) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "SaleOrders",
                type: "DECIMAL(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(9,2)");

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
    }
}
