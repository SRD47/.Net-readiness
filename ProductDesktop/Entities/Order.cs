namespace ProductDesktop.Entities
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned

    }
    public class Order
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public int Quantity {  get; set; }
        public string Notes { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateOnly OrderDate {  get; set; }
        public DateOnly ExpectedDeliveryDate { get; set; }
        public Guid SupplierId {  get; set; }
        public Supplier Supplier { get; set; } = null!;
    }
}
