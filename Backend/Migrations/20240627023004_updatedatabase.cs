using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "ImageLink", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3915), "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3926) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "ImageLink", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3938), "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3939) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreationDate", "ImageLink", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5287), "##", new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "ImageLink", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5305), "$$", new DateTime(2024, 6, 12, 21, 56, 28, 626, DateTimeKind.Local).AddTicks(5306) });
        }
    }
}
