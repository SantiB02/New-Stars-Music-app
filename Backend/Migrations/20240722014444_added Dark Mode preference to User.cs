using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedDarkModepreferencetoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DarkModeOn",
                table: "Users",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2309), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2398), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2401), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2404), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2404) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2406), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2407) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2409), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2409) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2411), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2414), new DateTime(2024, 7, 21, 22, 44, 44, 310, DateTimeKind.Local).AddTicks(2415) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DarkModeOn",
                table: "Users");

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
        }
    }
}
