using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductDesktop.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ExpectedDeliveryDate", "Notes", "OrderDate", "OrderStatus", "ProductName", "Quantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Urgent delivery", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Laptop", 5, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 2, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "For fresh stock", new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Organic Apples", 100, new Guid("22222222-2222-2222-2222-222222222222") },
                    { 3, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Office Chairs", 10, new Guid("33333333-3333-3333-3333-333333333333") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
