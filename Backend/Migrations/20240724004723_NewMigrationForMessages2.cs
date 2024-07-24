using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class NewMigrationForMessages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MessageBody = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreationDate", "LastModifiedDate", "MessageBody" },
                values: new object[] { 1, new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(7267), new DateTime(2024, 7, 23, 21, 47, 23, 439, DateTimeKind.Local).AddTicks(7250), "Bienvenido a nuestro sitio" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(846), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(871), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(874), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(877), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(880), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(881) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(883), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(886), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(888), new DateTime(2024, 7, 23, 20, 45, 42, 497, DateTimeKind.Local).AddTicks(889) });
        }
    }
}
