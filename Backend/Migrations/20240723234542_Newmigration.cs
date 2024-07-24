using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class Newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(846), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(871), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(874), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(877), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(880), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(881) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(883), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(886), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(888), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(889) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
