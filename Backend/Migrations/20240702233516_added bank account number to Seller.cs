using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedbankaccountnumbertoSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3687), new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3697) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3703), new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3706), new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3708), new DateTime(2024, 7, 2, 20, 35, 15, 819, DateTimeKind.Local).AddTicks(3709) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-7771829382",
                column: "BankAccountNumber",
                value: "378364817263174");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4647), new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4667), new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4667) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4669), new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4672), new DateTime(2024, 7, 2, 19, 56, 6, 874, DateTimeKind.Local).AddTicks(4673) });
        }
    }
}
