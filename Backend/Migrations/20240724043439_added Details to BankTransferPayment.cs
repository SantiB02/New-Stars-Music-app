using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedDetailstoBankTransferPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Payments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(4508), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(4507) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5776), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5779) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5784), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5785) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5787), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5789), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5792), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5795), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5797), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5798) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5800), new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 1, 34, 39, 49, DateTimeKind.Local).AddTicks(4470));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 629, DateTimeKind.Local).AddTicks(9654), new DateTime(2024, 7, 24, 1, 4, 6, 629, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(846), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(855), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(858), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(861), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(863), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(864) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(866), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(869), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(871), new DateTime(2024, 7, 24, 1, 4, 6, 630, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 1, 4, 6, 629, DateTimeKind.Local).AddTicks(9525));
        }
    }
}
