using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class deletedCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "Number", "UserId" },
                values: new object[] { 1, "1234567891234567", "default-identifier-3845746332" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3302), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4923), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4936), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4941), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4945), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4950), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4954), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4959), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4963), new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-0012827345",
                column: "JoinedOn",
                value: new DateTime(2024, 7, 24, 0, 57, 5, 38, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");
        }
    }
}
