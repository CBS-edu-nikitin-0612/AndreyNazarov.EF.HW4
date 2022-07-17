﻿using System;
using System.Collections.Generic;

namespace TaskAdd.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int LineItem { get; set; }
        public int? ProdId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product? Prod { get; set; }
    }
}
