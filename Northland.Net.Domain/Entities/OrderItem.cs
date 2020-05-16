namespace Northland.Net.Domain
{
    public class OrderItem:AuditableEntity
    {
        public long Id { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
    }
}