using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class datab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8600), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8621), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8624), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8627), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8627) });
        }
    }
}
