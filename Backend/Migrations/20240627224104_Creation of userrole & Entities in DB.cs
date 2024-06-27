using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class CreationofuserroleEntitiesinDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_ArtistId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Admin_Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "Discriminator");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Products",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ArtistId",
                table: "Products",
                newName: "IX_Products_SellerId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Address",
                keyValue: null,
                column: "Address",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4061), new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4062) });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Client" },
                    { 2, "Seller" },
                    { 3, "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "UserRoleId" },
                values: new object[] { "leomattsantana@gmail.com", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "UserRoleId" },
                values: new object[] { "santi@gmail.com", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserRoleId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Discriminator", "Email", "Role", "State", "UserRoleId" },
                values: new object[] { 4, "San Martin 135", "Admin", "bdiaz@gmail.com", "Admin", true, 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Discriminator", "Email", "State", "UserRoleId" },
                values: new object[] { 5, "San Martin 111", "Seller", "katyperry@gmail.com", true, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreationDate", "Description", "ImageLink", "LastModifiedDate", "Name", "Price", "SellerId", "State", "Stock" },
                values: new object[] { 2, "T-shirt", "1022", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4033), "Remera ACDC algodón", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4047), "Remera ACDC", 12500m, 5, true, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreationDate", "Description", "ImageLink", "LastModifiedDate", "Name", "Price", "SellerId", "State", "Stock" },
                values: new object[] { 4, "T-shirt", "1022", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4056), "Remera Mozart algodón", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4056), "Remera Mozart", 12500m, 5, true, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Code", "CreationDate", "Description", "ImageLink", "LastModifiedDate", "Name", "Price", "SellerId", "State", "Stock" },
                values: new object[] { 5, "T-shirt", "1022", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4059), "Remera Beethoven algodón", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 27, 19, 41, 4, 196, DateTimeKind.Local).AddTicks(4059), "Remera Beethoven", 12500m, 5, true, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_SellerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Products",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                newName: "IX_Products_ArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Role",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3938), new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { "ngomez@gmail.com", "Gomez", "Nicolas", "123456", "ngomez_cliente" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { "Jperez@gmail.com", "Perez", "Juan", "123456", "jperez" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastName", "Name", "Password", "UserName" },
                values: new object[] { "Garcia", "Jose", "123456", "jgarcia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastName", "Name", "Password", "Admin_Role", "State", "UserName", "UserType" },
                values: new object[] { 4, null, "bdiaz@gmail.com", "Bruno", "Diaz", "123456", "admin", true, "bdiaz", "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "LastName", "Name", "Password", "Role", "State", "UserName", "UserType" },
                values: new object[] { 5, null, "katyperry@gmail.com", "Perry", "Katy", "345", "Artist", true, "katyp", "Client" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ArtistId", "Category", "Code", "CreationDate", "Description", "ImageLink", "LastModifiedDate", "Name", "Price", "State", "Stock" },
                values: new object[] { 6, 5, "T-shirt", "1022", new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3915), "Remera ACDC algodón", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Semi_dry_suit_-_2604.png/256px-Semi_dry_suit_-_2604.png?20180603115529", new DateTime(2024, 6, 26, 23, 30, 4, 76, DateTimeKind.Local).AddTicks(3926), "Remera ACDC", 12500m, true, 10 });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_ArtistId",
                table: "Products",
                column: "ArtistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
