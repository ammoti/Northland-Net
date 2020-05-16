using System;
using System.Collections.Generic;
namespace Northland.Net.Domain
{
    public class User: AuditableEntity
    {
        public User() => Orders = new List<Order>();
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
        public IList<Order> Orders { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}