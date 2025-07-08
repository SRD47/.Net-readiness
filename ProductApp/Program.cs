// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.EntityFrameworkCore;
using ProductApp.Database;
using ProductApp.Models;   
using ProductApp.Service;
using ProductApp.DTO;
using ProductApp.Extension;


namespace ProductApp {

    class Program {

        static void Main(string[] args) {
            
            
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ProductDb;Integrated Security=True;Trust Server Certificate=True")
                .Options;

                using var context = new ProductDbContext(options);
                var productservice = new ProductDbService(context);

                Console.WriteLine("\t\t\tProduct App");
            try
            {
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

                            foreach (var item in ListProducts)
                                $"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}".InfoColor();
                            break;

                        //Create Product

                        case 2:

                            Console.WriteLine("\nEnter Product Name");
                            string name = Console.ReadLine();

                            string errorMsg = ValidationExtension.ValidateProName(name);

                            if(errorMsg != null) { 
                                errorMsg.WarnColor();
                            return;
                            }

                            Console.WriteLine("\nEnter Product Category:");
                            string category = Console.ReadLine();

                            Console.WriteLine("\nEnter Product Class");
                            string pclass = Console.ReadLine();

                            Console.WriteLine("\nEnter Quantity");
                            int quantity = Convert.ToInt16(Console.ReadLine());

                            Console.WriteLine("\nChoose Currency : 1. NRS 2.USD");
                            int chooseCurrency = Convert.ToInt32(Console.ReadLine());

                            Currency currency = (Currency)chooseCurrency;

                            Console.WriteLine("\nEnter Price");
                            double price = Convert.ToDouble(Console.ReadLine());

                            var newProduct = new Product
                            {

                                ProName = name,
                                Category = category,
                                Class = pclass,
                                Quantity = quantity,
                                Currency = currency,
                                Price = price,
                            };
                            productservice.AddProduct(newProduct);
                            "Product added successfully".SuccessColor();

                            break;

                        case 3:

                            foreach (var item in ListProducts)
                                $"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}".InfoColor();

                            Console.WriteLine("\nEnter the id of product you want to update");

                            int UpdateId = Convert.ToInt16(Console.ReadLine());

                            var UpdateProduct = ListProducts.FirstOrDefault(it => it.Id == UpdateId);

                            if (UpdateProduct == null) "Enter a valid Id of the given products".WarnColor();

                            else
                            {

                                Console.WriteLine("Enter new product name(blank to leave as it is)");
                                string NewName = Console.ReadLine();

                                Console.WriteLine("Enter new product category(blank to leave as it is)");
                                string NewCategory = Console.ReadLine();

                                Console.WriteLine("Enter new product class(blank to leave as it is)");
                                string NewClass = Console.ReadLine();

                                Console.WriteLine("Enter new product quantity(blank to leave as it is)");
                                string QuanInput = Console.ReadLine();

                                int? NewQuantity = null;    //int? means can be nullable and product model in database shoul also be changed to int?

                                if (!string.IsNullOrEmpty(QuanInput) && int.TryParse(QuanInput, out int ParsedQuantity))
                                    NewQuantity = ParsedQuantity;

                                Currency? NewCurrency = null;

                                Console.WriteLine("\nChoose Currency : 1. NRS 2.USD");
                                string NewCurrencyInput = Console.ReadLine();

                                if (!string.IsNullOrEmpty(NewCurrencyInput) && int.TryParse(NewCurrencyInput, out int ParsedCurrency))
                                    NewCurrency = (Currency)ParsedCurrency;


                                Console.WriteLine("Enter new product price(blank to leave as it is)");
                                string PriceInput = Console.ReadLine();

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

                                var returnResult = productservice.UpdateProduct(UpdateId, updatedProduct);

                                if (returnResult) "Product Updated Successfully".SuccessColor();
                                else "Failed to update the product.".ErrorColor();

                            }
                            break;

                        case 4:

                            foreach (var item in ListProducts)
                                $"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}".InfoColor();

                            Console.WriteLine("\nEnter Id of product to delete");

                            int IdDelete = Convert.ToInt16(Console.ReadLine());

                            if (IdDelete < 0)
                                "Enter id that is present in the product list above.".WarnColor();

                            var productdelete = ListProducts.FirstOrDefault(x => x.Id == IdDelete);

                            if (productdelete == null)
                                "Enter valid id from the list".WarnColor();
                            else
                            {
                                productservice.DeleteProduct(IdDelete);
                                "Product deleted successfully".SuccessColor();
                            }

                            break;

                        case 5:

                            Console.WriteLine("\nEnter the product name to filter out the products");
                            string FilterName = Console.ReadLine();

                            var FilteredProduct = productservice.FilterDataByName(FilterName);

                            if (FilteredProduct.Count == 0)
                                "No product/s found with such name".WarnColor();
                            else
                                foreach (var item in FilteredProduct)
                                    $"Id = {item.Id} | Name = {item.ProName} | Category = {item.Category} | Class = {item.Class} | Quantity = {item.Quantity} | Currency = {item.Currency} | Price = {item.Price}".InfoColor();

                        break;

                        case 6:
                            Console.WriteLine(".............Exiting the application...........");
                            return;
                        default:

                            "Unwanted error occured".ErrorColor();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

