using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedlocationdatatoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apartment",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-3845746332",
                columns: new[] { "Apartment", "City", "Country", "Phone", "PostalCode" },
                values: new object[] { "8A", "Rosario", "Argentina", "+5493416271920", "S2000" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-73619823",
                columns: new[] { "Apartment", "City", "Country", "Phone", "PostalCode" },
                values: new object[] { "7B", "Rosario", "Argentina", "+5493415678119", "S2000" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-945711463132",
                columns: new[] { "City", "Country", "Phone", "PostalCode" },
                values: new object[] { "Rosario", "Argentina", "+5493413457612", "S2000" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-7771829382",
                columns: new[] { "City", "Country", "Phone", "PostalCode" },
                values: new object[] { "Rosario", "Argentina", "+5493416781203", "S2000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9210), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9228), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9230), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9233), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "Address",
                value: "San Martin 135");
        }
    }
}
