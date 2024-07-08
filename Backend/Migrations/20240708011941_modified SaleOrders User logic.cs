using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class modifiedSaleOrdersUserlogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "SaleOrderLines");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "SaleOrders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "QuantityOrdered",
                table: "SaleOrderLines",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "OrderCode",
                table: "SaleOrders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SaleOrders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SaleOrderLines",
                newName: "QuantityOrdered");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderCode",
                table: "SaleOrders",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "SaleOrderLines",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8837), new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8856), new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8857) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8859), new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8859) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8861), new DateTime(2024, 7, 5, 19, 30, 36, 415, DateTimeKind.Local).AddTicks(8862) });
        }
    }
}
