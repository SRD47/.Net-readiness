using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductDesktop.Migrations
{
    /// <inheritdoc />
    public partial class supplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
