using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedWaitingValidationbooltoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WaitingValidation",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4478), new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4496), new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4499), new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4502), new DateTime(2024, 7, 3, 1, 8, 42, 665, DateTimeKind.Local).AddTicks(4502) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaitingValidation",
                table: "Users");

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
        }
    }
}
