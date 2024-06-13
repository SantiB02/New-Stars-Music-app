using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class Nuevamigracionpa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5287), new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5305), new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5306) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 7, 20, 59, 25, 680, DateTimeKind.Local).AddTicks(1765), new DateTime(2024, 6, 7, 20, 59, 25, 680, DateTimeKind.Local).AddTicks(1774) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 7, 20, 59, 25, 680, DateTimeKind.Local).AddTicks(1780), new DateTime(2024, 6, 7, 20, 59, 25, 680, DateTimeKind.Local).AddTicks(1780) });
        }
    }
}
