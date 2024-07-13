using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class MigracióndeLeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4223), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4244), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4248), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4297), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4298) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8655), new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8676), new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8677) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8680), new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8681) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8684), new DateTime(2024, 7, 11, 19, 15, 13, 635, DateTimeKind.Local).AddTicks(8684) });
        }
    }
}
