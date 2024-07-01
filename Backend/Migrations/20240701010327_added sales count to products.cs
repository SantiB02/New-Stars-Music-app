using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedsalescounttoproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate", "Sales" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7327), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7342), 237 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate", "Sales" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7348), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7348), 129 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate", "Sales" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7350), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7350), 83 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate", "Sales" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7352), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7353), 421 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sales",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9679), new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9699), new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9702), new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9706), new DateTime(2024, 6, 29, 23, 29, 57, 728, DateTimeKind.Local).AddTicks(9707) });
        }
    }
}
