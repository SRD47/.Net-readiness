using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practice.Data;
using Practice.Models.Entities;
using Practice.Services;
using Practice.Extensions; 

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var services = new ServiceCollection();
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        var provider = services.BuildServiceProvider();

        var db = provider.GetRequiredService<ApplicationDbContext>();
        db.Database.EnsureCreated();
        var service = new ProductService(db);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n1. Add\n2. View\n3. Delete\n4. Update\nYour choice:");
            Console.ResetColor();

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                var p = new Product();

                Console.Write("Name: ");
                var name = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(name) || name.Length < 6 || name.Length > 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ❌ Name must be between 6 and 20 characters.");
                    Console.ResetColor();
                    continue;
                }
                p.Name = name;

                Console.Write("Category: ");
                p.Category = Console.ReadLine() ?? "";

                Console.Write("Class: ");
                p.Class = Console.ReadLine() ?? "";

                Console.Write("Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ❌ Quantity must be a number greater than 0.");
                    Console.ResetColor();
                    continue;
                }
                p.Quantity = qty;

                Console.Write("Price: ");
                p.Price = Console.ReadLine() ?? "";

                Console.Write("Currency (USD/NRS): ");
                var currencyInput = Console.ReadLine();
                if (!Enum.TryParse<Currency>(currencyInput, true, out var currency))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ❌ Invalid currency. Only USD or NRS allowed.");
                    Console.ResetColor();
                    continue;
                }
                p.Currency = currency;

                service.Add(p);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ✅ Product added.");
                Console.ResetColor();
            }

            else if (choice == "2")
            {
                var all = service.GetAll();
                for (int i = 0; i < all.Count; i++)
                {
                    var p = all[i];
                    Console.WriteLine($"{i + 1}. {p.Name} {p.Quantity} {p.Currency.ToDisplayName} {p.Category} {p.Class} {p.Price}");
                }
            }

            else if (choice == "3")
            {
                var all = service.GetAll();
                for (int i = 0; i < all.Count; i++)
                    Console.WriteLine($"{i + 1}. {all[i].Name} ({all[i].Category})");

                Console.Write("Enter product number to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > all.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid input.");
                    Console.ResetColor();
                    continue;
                }
                service.Delete(all[index - 1].ID);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Deleted.");
                Console.ResetColor();
            }

            else if (choice == "4")
            {
                var all = service.GetAll();
                for (int i = 0; i < all.Count; i++)
                    Console.WriteLine($"{i + 1}. {all[i].Name} ({all[i].Category})");

                Console.Write("Enter product number to update: ");
                if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > all.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ❌ Invalid input.");
                    Console.ResetColor();
                    continue;
                }

                var p = all[index - 1];

                Console.Write("New Name (leave empty to skip): ");
                var n = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(n)) p.Name = n;

                Console.Write("New Quantity (leave empty to skip): ");
                var q = Console.ReadLine();
                if (int.TryParse(q, out int newQty)) p.Quantity = newQty;

                var err = service.Validate(p);
                if (err != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + err);
                    Console.ResetColor();
                    continue;
                }

                service.Update(p);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Updated.");
                Console.ResetColor();
            }
        }

    }
}
