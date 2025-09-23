using System.ComponentModel.DataAnnotations;

namespace ProductDesktop.Entities
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; } = Guid.NewGuid();
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public Category Category { get; set; }
        public string Description {  get; set; }
        [Phone]
        public string  PhoneNumber { get; set; }
        [EmailAddress]
        public string Email {  get; set; }
    }
}
