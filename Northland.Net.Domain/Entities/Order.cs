using System;
using System.Collections.Generic;

namespace Northland.Net.Domain
{
    public class Order:AuditableEntity
    {
        public Order() => OrderItems = new List<OrderItem>();
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public float TotalAmount { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
     }