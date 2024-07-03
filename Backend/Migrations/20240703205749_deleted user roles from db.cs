using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class deleteduserrolesfromdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3265), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3285), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3285) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3288), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3290), new DateTime(2024, 7, 3, 17, 57, 48, 940, DateTimeKind.Local).AddTicks(3291) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
