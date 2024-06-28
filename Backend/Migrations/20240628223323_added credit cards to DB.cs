using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedcreditcardstoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 1, "1234567891234567", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4640), new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4655), new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4656) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4658), new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4659) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4661), new DateTime(2024, 6, 28, 19, 33, 22, 987, DateTimeKind.Local).AddTicks(4661) });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8032), new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8050), new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8053), new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8056), new DateTime(2024, 6, 28, 16, 56, 59, 846, DateTimeKind.Local).AddTicks(8056) });
        }
    }
}
