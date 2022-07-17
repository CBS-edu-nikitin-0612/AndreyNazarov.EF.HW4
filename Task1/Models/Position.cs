using System;
using System.Collections.Generic;

namespace Task1.Models
{
    public partial class Position
    {
        public Position()
        {
            staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string Position1 { get; set; } = null!;
        public decimal? Salary { get; set; }

        public virtual ICollection<Staff> staff { get; set; }
    }
}
