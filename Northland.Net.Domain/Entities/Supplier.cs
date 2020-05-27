using System.Collections.Generic;
namespace Northland.Net.Domain
{
    public class Supplier : AuditableEntity
    {
        public Supplier() => Products = new List<Product>();
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public IList<Product> Products { get; set; }

    }
}