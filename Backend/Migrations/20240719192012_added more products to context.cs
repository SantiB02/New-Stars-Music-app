using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class addedmoreproductstocontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4772), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4784) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4789), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4792), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4792) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4795), new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4795) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArtistOrBand", "CategoryId", "Code", "CreationDate", "Description", "ImageLink", "LastModifiedDate", "Name", "Price", "Sales", "SellerId", "State", "Stock" },
                values: new object[,]
                {
                    { 8, "Flo Rida", 2, "e52x6", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4797), "Flo Rida's Wild Ones CD with his greatest hits!", "https://merchbar.imgix.net/product/cdified/upc/34/075678833403.jpg?q=40&auto=compress,format&w=1400", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4798), "Flo Rida's Wild Ones CD", 19200.11m, 129, "default-identifier-7771829382", true, 45 },
                    { 9, "David Guetta", 3, "45hgr", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4800), "Amazing David Guetta cap!", "https://ih1.redbubble.net/image.3597046453.2550/ssrco,baseball_cap,product,000000:44f0b734a5,front_three_quarter,wide_portrait,750x1000-bg,f8f8f8.jpg", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4800), "David Guetta cap", 10700.13m, 341, "default-identifier-7771829382", true, 34 },
                    { 10, "Avicii", 4, "46as3", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4802), "great and light Avicii bag!", "https://ih1.redbubble.net/image.1091821770.3226/drawstring_bag,x750-pad,750x1000,f8f8f8.u2.jpg", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4803), "Avicii bag", 15900.45m, 128, "default-identifier-7771829382", true, 12 },
                    { 11, "Coldplay", 5, "76fg1", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4805), "Really colorful Coldplay poster!", "https://acdn.mitiendanube.com/stores/001/113/338/products/coldplay11-d0585db969184a7c0716063455586064-640-0.jpg", new DateTime(2024, 7, 19, 16, 20, 12, 242, DateTimeKind.Local).AddTicks(4806), "Coldplay poster", 8450.99m, 451, "default-identifier-7771829382", true, 45 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4223), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4244), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4248), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4297), new DateTime(2024, 7, 12, 20, 31, 7, 56, DateTimeKind.Local).AddTicks(4298) });
        }
    }
}
