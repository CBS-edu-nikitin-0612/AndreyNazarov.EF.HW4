using System;
using System.Collections.Generic;

namespace TaskAdd.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerNo { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string? Mname { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime? DateInSystem { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
