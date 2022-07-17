using System;
using System.Collections.Generic;

namespace TaskAdd.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProdId { get; set; }
        public string Description { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
