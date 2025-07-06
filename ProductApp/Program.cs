// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.EntityFrameworkCore;
using ProductApp.Database;
using ProductApp.Models;
using ProductApp.Service;
using ProductApp.DTO;


namespace ProductApp {

    class Program {

        static void Main(string[] args) {

              var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True;Trust Server Certificate=True")
                .Options;

                using var context = new ProductDbContext(options);
                var productservice = new ProductDbService(context);

                Console.WriteLine("\t\t\tProduct App");
            while (true) { 
                    Console.WriteLine("\nChoose:");
                    Console.WriteLine("\n1. View Product List");
                    Console.WriteLine("\n2. Create a new Product");
                    Console.WriteLine("\n3. Update a new Product");
                    Console.WriteLine("\n4. Delete a new Product");
                    Console.WriteLine("\n5. Filter Product by name");
                    Console.WriteLine("\n6. Exit the application\n");
                    

                    int value = Convert.ToInt16(Console.ReadLine());

                    var ListProducts = productservice.ViewProducts();

                switch (value)
                {
                    //View Products

                    case 1:

                        foreach(var item in ListProducts)
                            Console.WriteLine($"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}");
                    break;

                    //Create Product

                    case 2:

                        Console.WriteLine("\nEnter Product Name");
                        string name = Console.ReadLine();

                        if (string.IsNullOrEmpty(name))
                            throw new ArgumentNullException("Cannot be null");

                        if (name.Length < 5 || name.Length > 20)
                            throw new Exception("Enter Product Name between 5 and 20  characters");

                        Console.WriteLine("\nEnter Product Category:");
                        string category = Console.ReadLine();

                        Console.WriteLine("\nEnter Product Class");
                        string pclass = Console.ReadLine();

                        Console.WriteLine("\nEnter Quantity");
                        int quantity = Convert.ToInt16(Console.ReadLine());

                        Console.WriteLine("\nChoose Currency : 1. NRS 2.USD");
                        int chooseCurrency =Convert.ToInt32(Console.ReadLine());

                        Currency currency = (Currency)chooseCurrency;

                        Console.WriteLine("\nEnter Price");
                        double price = Convert.ToDouble(Console.ReadLine());

                        var newProduct = new Product { 
                            
                            ProName = name,
                            Category = category,
                            Class = pclass,
                            Quantity = quantity,
                            Currency = currency,
                            Price = price,
                        };
                        productservice.AddProduct(newProduct);
                        Console.WriteLine("Product added successfully");
                    
                    break;
                    
                    case 3:
                        Console.WriteLine("Update");

                        foreach (var item in ListProducts)
                            Console.WriteLine($"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}");

                        Console.WriteLine("Enter the id of product you want to update");

                        int UpdateId = Convert.ToInt16(Console.ReadLine());

                        var UpdateProduct = ListProducts.FirstOrDefault(it => it.Id == UpdateId);

                        if (UpdateProduct == null) Console.WriteLine("Enter a valid Id of the given products");
                    
                        else { 

                            Console.WriteLine("Enter new product name(blank to leave as it is)");
                            string NewName = Console.ReadLine();

                            Console.WriteLine("Enter new product category(blank to leave as it is)");
                            string NewCategory =  Console.ReadLine();

                            Console.WriteLine("Enter new product class(blank to leave as it is)");
                            string NewClass =  Console.ReadLine();

                            Console.WriteLine("Enter new product quantity(blank to leave as it is)");
                            string QuanInput = Console.ReadLine();

                            int? NewQuantity = null;    //int? means can be nullable and product model in database shoul also be changed to int?

                            if(!string.IsNullOrEmpty(QuanInput) && int.TryParse(QuanInput, out int ParsedQuantity))
                                NewQuantity = ParsedQuantity;

                            Currency? NewCurrency = null;

                            Console.WriteLine("\nChoose Currency : 1. NRS 2.USD");
                            string NewCurrencyInput = Console.ReadLine();

                            if (!string.IsNullOrEmpty(NewCurrencyInput) && int.TryParse(NewCurrencyInput, out int ParsedCurrency))
                                NewCurrency = (Currency)ParsedCurrency;

                        
                            Console.WriteLine("Enter new product price(blank to leave as it is)");
                            string PriceInput =  Console.ReadLine();

                            double? NewPrice = null;

                            if (!string.IsNullOrEmpty(PriceInput) && double.TryParse(PriceInput, out double ParsedPrice))
                                NewPrice = ParsedPrice;

                            var updatedProduct = new ProductUpdateDto
                            {
                                ProName = NewName,
                                Category = NewCategory,
                                Class = NewClass,
                                Quantity = NewQuantity,
                                Currency = NewCurrency,
                                Price = NewPrice,
                            };

                            var returnResult = productservice.UpdateProduct(UpdateId,updatedProduct);

                            if(returnResult) Console.WriteLine("Product Updated Successfully");
                            else Console.WriteLine("Failed to update the product.");

                        }
                    break;

                    case 4:

                        foreach(var item in ListProducts)
                            Console.WriteLine($"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}");

                        Console.WriteLine("Enter Id of product to delete");

                        int IdDelete = Convert.ToInt16(Console.ReadLine());

                        if(IdDelete < 0)
                            Console.WriteLine("Enter id that is present in the product list above.");

                        var productdelete = ListProducts.FirstOrDefault(x => x.Id == IdDelete);

                        if(productdelete == null)
                            Console.WriteLine("Enter valid id from the list");
                        else
                        {
                            productservice.DeleteProduct(IdDelete);
                            Console.WriteLine("Product deleted successfully");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter the product name to filter out the products");
                        string FilterName = Console.ReadLine();

                        var FilteredProduct = productservice.FilterDataByName(FilterName);

                        if (FilteredProduct.Count == 0)
                            Console.WriteLine("No product/s found with such name");
                        else
                            foreach (var item in FilteredProduct)
                                Console.WriteLine($"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}");

                    break;
                    case 6:
                        Console.WriteLine(".............Exiting the application...........");
                        return;
                    default:
                        Console.WriteLine("Unwanted error occured");
                        break;
                }
            }
        }       
    }
}

