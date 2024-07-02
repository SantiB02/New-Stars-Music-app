using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addArtistOrBandpropertytoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistOrBand",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistOrBand", "CreationDate", "LastModifiedDate", "Price", "Stock" },
                values: new object[] { "ACDC", new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9210), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9221), 12500.71m, 19 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistOrBand", "Code", "CreationDate", "LastModifiedDate", "Price", "Stock" },
                values: new object[] { "Mozart", "18az4", new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9228), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9228), 23763.34m, 24 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistOrBand", "Code", "CreationDate", "LastModifiedDate", "Price" },
                values: new object[] { "Beethoven", "17zz89", new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9230), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9231), 12500.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArtistOrBand", "Code", "CreationDate", "LastModifiedDate", "Price" },
                values: new object[] { "LOVG", "ax34d", new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9233), new DateTime(2024, 7, 2, 2, 10, 49, 675, DateTimeKind.Local).AddTicks(9234), 13200.11m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistOrBand",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate", "Price", "Stock" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2963), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2973), 12500m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "CreationDate", "LastModifiedDate", "Price", "Stock" },
                values: new object[] { "1022", new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2978), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2978), 12500m, 10 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "CreationDate", "LastModifiedDate", "Price" },
                values: new object[] { "1022", new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2980), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2981), 12500m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "CreationDate", "LastModifiedDate", "Price" },
                values: new object[] { "1021", new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2983), 13200m });
        }
    }
}
