// See https://aka.ms/new-console-template for more information
using ProductApp.Database; 
using ProductApp.Service;
using ProductApp.Extension;
using ProductApp.UILogic;


namespace ProductApp {

    class Program {

        static void Main(string[] args) {

            using var context = DbConnection.CreateConnection();
            var productservice = new ProductDbService(context);
            var ui = new UIService(productservice);

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
                            ListProducts.DisplayProductAll();
                        break;

                        //Create Product

                        case 2:
                            ui.CreateProduct();

                            break;

                        case 3:
                            ui.UpdateProduct();

                        break;

                        case 4:

                            ListProducts.DisplayProductAll();

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

