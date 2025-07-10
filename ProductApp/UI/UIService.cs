using ProductApp.Database;
using ProductApp.DTO;
using ProductApp.Extension;
using ProductApp.Service; 

namespace ProductApp.UILogic
{
    public class UIService
    {
        private readonly ProductDbService _dbService;

        public UIService(ProductDbService dbService)
        {
            _dbService = dbService; 
        }

        public void CreateProduct()
        {

            Console.WriteLine("\nEnter Product Name");
            string name = Console.ReadLine();

            string errorMsg = ValidationExtension.ValidateProName(name);

            if (errorMsg != null)
            {
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
            decimal price = Convert.ToDecimal(Console.ReadLine());

            var newProduct = new Product
            {

                ProName = name,
                Category = category,
                Class = pclass,
                Quantity = quantity,
                Currency = currency,
                Price = price,
            };
            _dbService.AddProduct(newProduct);
            "Product added successfully".SuccessColor();
        }
        public void UpdateProduct()
        {
            Console.WriteLine("\nEnter the id of product you want to update");

            int UpdateId = Convert.ToInt16(Console.ReadLine());
            var ListProducts = _dbService.ViewProducts();

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
                int? NewQuantity = ValidationExtension.ParseInt(Console.ReadLine());

                Currency? NewCurrency = null;

                Console.WriteLine("\nChoose Currency : 1. NRS 2.USD");
                string NewCurrencyInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(NewCurrencyInput) && int.TryParse(NewCurrencyInput, out int ParsedCurrency))
                    NewCurrency = (Currency)ParsedCurrency;


                Console.WriteLine("Enter new product price(blank to leave as it is)");
                decimal? NewPrice = ValidationExtension.ParseDecimal(Console.ReadLine());

                var updatedProduct = new ProductUpdateDto
                {
                    ProName = NewName,
                    Category = NewCategory,
                    Class = NewClass,
                    Quantity = NewQuantity,
                    Currency = NewCurrency,
                    Price = NewPrice,
                };

                var returnResult = _dbService.UpdateProduct(UpdateId, updatedProduct);

                if (returnResult) "Product Updated Successfully".SuccessColor();
                else "Failed to update the product.".ErrorColor();

            }
        }
    }
}
