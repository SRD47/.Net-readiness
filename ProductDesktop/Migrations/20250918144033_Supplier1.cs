using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductDesktop.Migrations
{
    /// <inheritdoc />
    public partial class Supplier1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("4ce9eaab-46a5-4d16-8d0b-178e3e041e50"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("6b7ec4b8-fced-4d1c-bde0-778a1bc31838"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("e653df17-a5b0-4615-a836-f5be82bf8490"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("e6d978f8-8c87-4a2b-9129-bf70e0b97919"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("fddd48c7-379d-493e-b27f-528a5695c878"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Category", "ContactPerson", "Description", "Email", "PhoneNumber", "Price", "Quantity", "SupplierName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "ElectronicsAndAppliances", "John Doe", "Electronic gadgets and accessories", "abc@traders.com", "9876543210", 50.0, 100, "ABC Traders" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "FoodAndBeverages", "Alice Green", "Fresh fruits and vegetables", "alice@freshfarm.com", "9876543211", 2.5, 500, "Fresh Farm Ltd" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "HomeAndLiving", "Bob Smith", "Kitchen and home appliances", "bob@homestyle.com", "9876543212", 150.0, 50, "HomeStyle" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "ClothingAndFashion", "Carol White", "Clothing and fashion accessories", "carol@fashionhub.com", "9876543213", 25.0, 200, "FashionHub" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "HomeAndLiving", "David Brown", "Office supplies and stationery", "david@officeessentials.com", "9876543214", 1.5, 300, "Office Essentials" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Category", "ContactPerson", "Description", "Email", "PhoneNumber", "Price", "Quantity", "SupplierName" },
                values: new object[,]
                {
                    { new Guid("4ce9eaab-46a5-4d16-8d0b-178e3e041e50"), "FoodAndBeverages", "Alice Green", "Fresh fruits and vegetables", "alice@freshfarm.com", "9876543211", 2.5, 500, "Fresh Farm Ltd" },
                    { new Guid("6b7ec4b8-fced-4d1c-bde0-778a1bc31838"), "ClothingAndFashion", "Carol White", "Clothing and fashion accessories", "carol@fashionhub.com", "9876543213", 25.0, 200, "FashionHub" },
                    { new Guid("e653df17-a5b0-4615-a836-f5be82bf8490"), "HomeAndLiving", "David Brown", "Office supplies and stationery", "david@officeessentials.com", "9876543214", 1.5, 300, "Office Essentials" },
                    { new Guid("e6d978f8-8c87-4a2b-9129-bf70e0b97919"), "ElectronicsAndAppliances", "John Doe", "Electronic gadgets and accessories", "abc@traders.com", "9876543210", 50.0, 100, "ABC Traders" },
                    { new Guid("fddd48c7-379d-493e-b27f-528a5695c878"), "HomeAndLiving", "Bob Smith", "Kitchen and home appliances", "bob@homestyle.com", "9876543212", 150.0, 50, "HomeStyle" }
                });
        }
    }
}
