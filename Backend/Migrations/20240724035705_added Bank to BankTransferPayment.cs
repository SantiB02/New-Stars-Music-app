using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedBanktoBankTransferPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Payments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3302), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4923), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4936), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4941), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4945), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4950), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4954), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4959), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4963), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3252));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7291), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8347), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8353), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8356), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8361), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8364), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8367), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8371), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7260));
        }
    }
}
