using Practice.Data;
using Practice.Models.Entities;

namespace Practice.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public string? Validate(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name) || p.Name.Length < 6 || p.Name.Length > 20)
                return "Name must be between 6 and 20 characters.";

            if (p.Quantity <= 0)
                return "Quantity must be greater than 0.";

            if (!Enum.IsDefined(typeof(Currency), p.Currency))
                return "Invalid currency. Only USD or NRS allowed.";

            return null;
        }

        public void Add(Product p)
        {
            _db.Products.Add(p);
            _db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public Product? GetById(Guid id)
        {
            return _db.Products.Find(id);
        }

        public void Delete(Guid id)
        {
            var p = _db.Products.Find(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                _db.SaveChanges();
            }
        }

        public void Update(Product p)
        {
            var old = _db.Products.Find(p.ID);
            if (old != null)
            {
                old.Name = p.Name;
                old.Category = p.Category;
                old.Class = p.Class;
                old.Quantity = p.Quantity;
                old.Price = p.Price;
                old.Currency = p.Currency;
                _db.SaveChanges();
            }
        }

        public List<Product> FilterByName(string name)
        {
            return _db.Products.Where(p => p.Name.Contains(name)).ToList();
        }
    }
}