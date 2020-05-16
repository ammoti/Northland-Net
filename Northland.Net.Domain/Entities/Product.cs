using System;
using System.Collections.Generic;
namespace Northland.Net.Domain
{
    public class Product:AuditableEntity
    {
        public Product() => OrderItems = new List<OrderItem>();
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public float UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }
        public Supplier Supplier { get; set; }
        public long SupplierId { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}