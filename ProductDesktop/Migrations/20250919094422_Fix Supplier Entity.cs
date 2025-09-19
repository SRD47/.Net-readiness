using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductDesktop.Migrations
{
    /// <inheritdoc />
    public partial class FixSupplierEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Suppliers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Suppliers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 50.0, 100 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 2.5, 500 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 150.0, 50 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 25.0, 200 });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Price", "Quantity" },
                values: new object[] { 1.5, 300 });
        }
    }
}
