using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class removedReceiverfromPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_ReceiverId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ReceiverId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(6299), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7923), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7926), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7926) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7928), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7929) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7931), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7931) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7933), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7934) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7936), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7936) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7938), new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 1, 48, 16, 28, DateTimeKind.Local).AddTicks(6266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Payments",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReceiverId",
                table: "Payments",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_ReceiverId",
                table: "Payments",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
