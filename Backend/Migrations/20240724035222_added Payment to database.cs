using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedPaymenttodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedOn",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Purchases",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME(0)", nullable: false),
                    PayerId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceiverId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Installments = table.Column<int>(type: "int", nullable: true),
                    AmountPerInstallment = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_PayerId",
                        column: x => x.PayerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7291), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8347), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8353), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8356), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8361), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8364), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8367), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8371), new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 0, 52, 21, 802, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PayerId",
                table: "Payments",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReceiverId",
                table: "Payments",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropColumn(
                name: "JoinedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Purchases",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(7267), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8026), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8037), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8041), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8044), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8044) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8047), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8049), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8052), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8055), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(8056) });
        }
    }
}
