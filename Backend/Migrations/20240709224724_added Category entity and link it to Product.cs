using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedCategoryentityandlinkittoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-shirts" },
                    { 2, "CDs" },
                    { 3, "Caps" },
                    { 4, "Bags" },
                    { 5, "Posters" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreationDate", "LastModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8600), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreationDate", "LastModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8621), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreationDate", "LastModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8624), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreationDate", "LastModifiedDate" },
                values: new object[] { 1, new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8627), new DateTime(2024, 7, 9, 19, 47, 23, 510, DateTimeKind.Local).AddTicks(8627) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreationDate", "LastModifiedDate" },
                values: new object[] { "T-shirt", new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3660), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3673) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "CreationDate", "LastModifiedDate" },
                values: new object[] { "T-shirt", new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3680), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "CreationDate", "LastModifiedDate" },
                values: new object[] { "T-shirt", new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3684) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "CreationDate", "LastModifiedDate" },
                values: new object[] { "T-shirt", new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3687), new DateTime(2024, 7, 7, 23, 30, 3, 415, DateTimeKind.Local).AddTicks(3688) });
        }
    }
}
