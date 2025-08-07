using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductDesktop.Migrations
{
    /// <inheritdoc />
    public partial class dbanddataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Name", "Password", "Roles", "Username" },
                values: new object[] { 1, "Admin", "admin", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Currency", "InStock", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Electronics", "USD", 10, "Laptop", 999.99000000000001, 20 },
                    { 2, "Electronics", "USD", 25, "Smartphone", 599.49000000000001, 30 },
                    { 3, "Furniture", "USD", 0, "Desk Chair", 149.99000000000001, 10 },
                    { 4, "Electronics", "INR", 15, "Monitor", 199.99000000000001, 25 },
                    { 5, "Stationery", "NRS", 100, "Pen", 0.98999999999999999, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
