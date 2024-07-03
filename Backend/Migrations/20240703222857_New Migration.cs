using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4765), new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4790), new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4796), new DateTime(2024, 7, 3, 19, 28, 56, 876, DateTimeKind.Local).AddTicks(4797) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3265), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3285), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3288), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3290), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3291) });
        }
    }
}
