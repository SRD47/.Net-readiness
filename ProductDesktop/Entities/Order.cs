namespace ProductDesktop.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }
        public int Quantity {  get; set; }
        public string Notes { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDate {  get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
