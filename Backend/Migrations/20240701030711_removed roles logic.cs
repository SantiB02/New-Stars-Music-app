using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merchanmusic.Migrations
{
    public partial class removedroleslogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2963), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2978), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2980), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2981) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 7, 1, 0, 7, 11, 298, DateTimeKind.Local).AddTicks(2983) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7327), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7348), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7350), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7352), new DateTime(2024, 6, 30, 22, 3, 26, 942, DateTimeKind.Local).AddTicks(7353) });

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
                keyValue: "default-identifier-0012827345",
                column: "UserRoleId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-3845746332",
                column: "UserRoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-73619823",
                column: "UserRoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-945711463132",
                column: "UserRoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "default-identifier-7771829382",
                column: "UserRoleId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
