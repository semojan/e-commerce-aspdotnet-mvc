using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _04_06_01_ecommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productviewcount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 10, 11, 10, 47, 43, 702, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 10, 11, 10, 47, 43, 704, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 10, 11, 10, 47, 43, 704, DateTimeKind.Local).AddTicks(9904));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2024, 10, 4, 12, 7, 59, 614, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2024, 10, 4, 12, 7, 59, 616, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2024, 10, 4, 12, 7, 59, 616, DateTimeKind.Local).AddTicks(9128));
        }
    }
}
